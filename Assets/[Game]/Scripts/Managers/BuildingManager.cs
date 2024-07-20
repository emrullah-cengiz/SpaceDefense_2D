using System;
using System.Collections;
using UnityEngine;
using Zenject;

public class BuildingManager : MonoBehaviour
{
    public BuildingPlace SelectedBuildingPlace { get; private set; }
    public Building SelectedBuilding { get; private set; }

    private void OnEnable()
    {
        Events.BuildingEvents.onBuildingPlaceSelected += SetSelectedBuildingPlace;
        Events.BuildingEvents.onBuildingSpawned += SetSelectedBuilding;
        Events.UI.onBuildingMenuActivenessChanged += ClearSelectedBuildingPlaceIfMenuInactive;
    }

    private void OnDisable()
    {
        Events.BuildingEvents.onBuildingPlaceSelected -= SetSelectedBuildingPlace;
        Events.BuildingEvents.onBuildingSpawned -= SetSelectedBuilding;
        Events.UI.onBuildingMenuActivenessChanged -= ClearSelectedBuildingPlaceIfMenuInactive;
    }

    private void SetSelectedBuildingPlace(BuildingPlace place) => 
        SelectedBuildingPlace = place;

    private void SetSelectedBuilding(Building building)
    {
        SelectedBuilding = building;

        SelectedBuildingPlace.Enable(false);
        SelectedBuildingPlace = null;
    }

    private void ClearSelectedBuildingPlaceIfMenuInactive(bool s)
    {
        if (!s)
            SelectedBuildingPlace = null;
    }
}
