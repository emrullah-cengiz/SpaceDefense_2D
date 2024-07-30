using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public interface IMemoryPoolGroup { }
public interface IMemoryPoolParams { }

public abstract class MemoryPoolGroup<TGroupParamsModel, TContract, TGroupEnum, TPool> : MemoryPoolGroup<TGroupEnum, TPool>
    where TGroupParamsModel : IMemoryPoolParams
    where TGroupEnum : Enum
    where TPool : IMemoryPool<TGroupParamsModel, TContract>
{
    public TContract Spawn(TGroupEnum type, TGroupParamsModel p1) => GetPool(type).Spawn(p1);
    public void Despawn(TContract obj, TGroupEnum type) => GetPool(type).Despawn(obj);
}

public abstract class MemoryPoolGroup<TGroupEnum, TPool> where TGroupEnum : Enum
                                                         where TPool : IMemoryPool
{
    private Dictionary<TGroupEnum, TPool> _pools;

    private DiContainer _diContainer;

    [Inject]
    private void Construct(DiContainer diContainer)
    {
        _diContainer = diContainer;

        _pools = new();

        Initialize();
    }

    private void Initialize()
    {
        foreach (TGroupEnum typeEnum in Enum.GetValues(typeof(TGroupEnum)))
            _pools.Add(typeEnum, (TPool)(IMemoryPool)_diContainer.ResolveId<TPool>(typeEnum));
    }

    protected TPool GetPool(TGroupEnum type) => _pools[type];

    //public TCon Spawn()

}
