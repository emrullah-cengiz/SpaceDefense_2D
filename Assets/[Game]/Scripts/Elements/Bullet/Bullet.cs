using System;
using System.Collections;
using UnityEngine;
using Zenject;
using static Bullet.Pool;

public class Bullet : MonoBehaviour, IPoolable<ParamsModel>
{
    public BulletType BulletType;

    [SerializeField]
    private float _targetReachTreshold;
    private float _targetReachTresholdSqr;

    private ParamsModel _bulletParams;

    private Vector3 _velocity;

    [Inject]
    private PoolGroup _poolGroup;

    private void Start()
    {
        _targetReachTresholdSqr = _targetReachTreshold * _targetReachTreshold;
    }

    public void OnSpawned(ParamsModel data)
    {
        _bulletParams = data;

        _velocity = (_bulletParams.TargetPos - _bulletParams.StartPos).normalized * _bulletParams.Speed;

        transform.LookAt(_bulletParams.TargetPos, Vector3.forward);
    }

    public void OnDespawned()
    {
        _velocity = Vector3.zero;
    }

    private void Update()
    {
        transform.Translate(_velocity * Time.deltaTime, Space.World);

        if ((transform.position - _bulletParams.TargetPos).sqrMagnitude <= _targetReachTresholdSqr)
            OnTargetReached();
    }

    private void OnTargetReached() => _poolGroup.Despawn(this, BulletType);

    public class PoolGroup : MemoryPoolGroup<ParamsModel, Bullet, BulletType, Pool>, IMemoryPoolGroup { }
    public class Pool : MonoPoolableMemoryPool<ParamsModel, Bullet>, IMemoryPool
    {
        public struct ParamsModel : IMemoryPoolParams
        {
            public Vector3 StartPos { get; set; }
            public Vector3 TargetPos { get; set; }
            public float Speed { get; set; }
            public int Damage { get; set; }
        }
    }
}
