using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class BuildingSpawner : MonoBehaviour
{
    private Building.Pool _pool;
    private BuildingManager _buildingManager;

    [Inject]
    void Construct(Building.Pool pool, BuildingManager buildingManager)
    {
        _pool = pool;
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
        var building = _pool.Spawn(data, _buildingManager.SelectedBuildingPlace.transform.position);

        Events.BuildingEvents.onBuildingSpawned?.Invoke(building);
    }
}
