using System;
using System.Collections;
using UnityEngine;
using Zenject;

public class UIManager : MonoBehaviour
{
    [SerializeField] private BuildingMenuUI _buildingMenu;

    [Inject]
    private void Construct()
    {
        //Events.BuildingEvents.onBuildingPlaceSelected += _buildingMenu.Show;
    }
}
