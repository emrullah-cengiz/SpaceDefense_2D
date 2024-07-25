using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class BuildingSpawner : MonoBehaviour
{
    private Building.PoolGroup _poolGroup;

    private BuildingManager _buildingManager;

    [Inject]
    void Construct(Building.PoolGroup poolGroup, BuildingManager buildingManager)
    {
        _poolGroup = poolGroup;
        _buildingManager = buildingManager;
    }

    private void OnEnable()
    {
        Events.BuildingEvents.onBuildingConstructionSeleted += Build;
    }

    private void OnDisable()
    {
        Events.BuildingEvents.onBuildingConstructionSeleted -= Build;
    }

    private void Build(BuildingData data)
    {
        var building = _poolGroup.Spawn(data.Type, new Building.PoolGroup.PoolGroupParams()
        {
            Data = data,
            Position = _buildingManager.SelectedBuildingPlace.transform.position
        });

        Events.BuildingEvents.onBuildingSpawned?.Invoke(building);
    }
}
