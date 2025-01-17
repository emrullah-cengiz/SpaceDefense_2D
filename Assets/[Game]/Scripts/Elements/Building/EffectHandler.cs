﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

public class EffectHandler : MonoBehaviour
{
    public List<Vector3> BarrelPoints;

    [Inject] private EffectFactory _effectFactory;

    private List<Enemy> _targetableEnemies;
    private IEffect _effect;

    public void Setup(EffectDefinitionBase definition)
    {
        _targetableEnemies = new();

        _effect = _effectFactory.Create(definition, this);

        _effect.Initialize();
    }

    public List<Enemy> GetCurrentTargets(int n) => _targetableEnemies.Take(n).ToList();

    private void OnTriggerEnter2D(Collider2D collision) => HandleTrigger(collision, true);
    private void OnTriggerExit2D(Collider2D collision) => HandleTrigger(collision, false);

    private void HandleTrigger(Collider2D collision, bool isEntering)
    {
        if (!collision.CompareTag(Tags.ENEMY) || !collision.TryGetComponent<Enemy>(out var enemy))
            return;

        bool changeActiveState = _targetableEnemies.Count == (isEntering ? 0 : 1);

        if (isEntering)
            _targetableEnemies.Add(enemy);
        else
            _targetableEnemies.Remove(enemy);

        if (changeActiveState)
            _effect.Activate(isEntering);
    }

    private void OnDrawGizmos()
    {
        if (!(BarrelPoints?.Count > 0))
            return;

        Gizmos.color = Color.cyan;

        foreach (var pos in BarrelPoints)
            Gizmos.DrawSphere(transform.position + pos, .1f);
    }

}
