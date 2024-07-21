using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using static Building;

public class Building : MonoBehaviour, IPoolable<PoolGroupParams>
{
    public BuildingData Data { get; private set; }

    [SerializeField] private SpriteRenderer _sprite;
    [SerializeField] private List<Vector3> _barrelPoints;

    public void OnSpawned(PoolGroupParams attrs)
    {
        Data = attrs.Data;

        _sprite.sprite = Data.Sprite;

        transform.position = attrs.Position;
    }

    public void OnDespawned()
    {

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


    public class Pool : MonoPoolableMemoryPool<PoolGroupParams, Building>, IMemoryPool
    {
    }

    public class PoolGroup : MemoryPoolGroup<PoolGroupParams, Building, BuildingType, Building.Pool>, IMemoryPoolGroup
    {
    }

    public struct PoolGroupParams : IMemoryPoolGroupParams
    {
        public BuildingData Data { get; set; }
        public Vector3 Position { get; set; }
    }
}
