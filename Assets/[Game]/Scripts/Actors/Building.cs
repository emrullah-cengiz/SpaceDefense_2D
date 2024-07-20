using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Building : MonoBehaviour
{
    public BuildingData Data { get; private set; }

    [SerializeField] private SpriteRenderer _sprite;
    [SerializeField] private List<Vector3> _barrelPoints;

    public void OnSpawned(BuildingData data, Vector3 pos)
    {
        Data = data;
        
        _sprite.sprite = Data.Sprite;
        
        transform.position = pos;
    }

    private void OnDrawGizmos()
    {
        if (!(_barrelPoints?.Count > 0))
            return;

        Gizmos.color = Color.cyan;

        foreach (var pos in _barrelPoints)
        {
            Gizmos.DrawSphere(transform.position + pos, .1f);
        }
    }

    public class Pool : MonoMemoryPool<BuildingData, Vector3, Building>
    {
        protected override void Reinitialize(BuildingData data, Vector3 pos, Building item)
        {
            item.OnSpawned(data, pos);
        }
    }
}
