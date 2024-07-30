using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using static Building.PoolGroup;

public class Building : MonoBehaviour, IPoolable<PoolGroupParams>
{
    public BuildingData Data { get; private set; }

    [SerializeField] private SpriteRenderer _sprite;

    [SerializeField] private EffectHandler _effectHandler;

    private void OnCreated()
    {

    }

    public void OnSpawned(PoolGroupParams args)
    {
        Data = args.Data;

        _sprite.sprite = Data.Sprite;

        transform.position = args.Position;

        _effectHandler.Setup(Data.EffectDefinition);
    }

    public void OnDespawned()
    {

    }

    public class Pool : MonoPoolableMemoryPool<PoolGroupParams, Building>, IMemoryPool
    {
        protected override void OnCreated(Building building)
        {
            base.OnCreated(building);

            building.OnCreated();
        }
    }


    public class PoolGroup : MemoryPoolGroup<PoolGroupParams, Building, BuildingType, Pool>, IMemoryPoolGroup
    {
        public struct PoolGroupParams : IMemoryPoolParams
        {
            public BuildingData Data { get; set; }
            public Vector3 Position { get; set; }
        }
    }
}
