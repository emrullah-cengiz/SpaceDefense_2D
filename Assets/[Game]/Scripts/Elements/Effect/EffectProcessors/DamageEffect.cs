using System.Collections;
using UnityEngine;
using Zenject;

public class DamageEffect : EffectBase
{
    [Inject] private readonly Bullet.PoolGroup _bulletPool;

    private readonly DamageEffectDefinition _tempEffectDefinition;
    private readonly BuildingManager _buildingManager;

    private Coroutine _fireCoroutine;
    private Bullet.Pool.ParamsModel _bulletParams;

    public DamageEffect(DamageEffectDefinition effectDefinition, EffectHandler effectHandler, BuildingManager buildingManager) : base(effectDefinition, effectHandler)
    {
        _tempEffectDefinition = effectDefinition;
        _buildingManager = buildingManager;

        _bulletParams = new();
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
            _bulletParams.Damage = _tempEffectDefinition.Damage;
            _bulletParams.Speed = _tempEffectDefinition.FireSpeed;
            _bulletParams.StartPos = _effectHandler.transform.position + _effectHandler.BarrelPoints[0];
            _bulletParams.TargetPos = _effectHandler.GetCurrentTargets(1)[0].transform.position;

            _bulletPool.Spawn(Data.BulletPrefab.BulletType, _bulletParams);

            //Debug.Log("fire " + _tempEffectDefinition.Damage); 

            yield return CoroutineExtensions.GetCachedWFS(1 / _tempEffectDefinition.FireRate);
        }
    }

}
