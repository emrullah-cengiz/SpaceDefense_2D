using System.Collections;
using UnityEngine;

public class DamageEffect : EffectBase
{
    private DamageEffectDefinition _tempEffectDefinition;
    private BuildingManager _buildingManager;

    private Coroutine _fireCoroutine;

    public DamageEffect(DamageEffectDefinition effectDefinition, BuildingManager buildingManager) : base(effectDefinition)
    {
        _tempEffectDefinition = effectDefinition;
        _buildingManager = buildingManager;
    }

    protected override void OnEnable()
    {
        _fireCoroutine = _buildingManager.StartCoroutine(Fire());
    }

    protected override void OnDisable()
    {
        _buildingManager.StopCoroutine(_fireCoroutine);
    }

    IEnumerator Fire()
    {
        while (true)
        {
            Debug.Log("fire " + _tempEffectDefinition.Damage); 

            yield return CoroutineExtensions.GetCachedWFS(1 / _tempEffectDefinition.FireRate);
        }
    }

}
