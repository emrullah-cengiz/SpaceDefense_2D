using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public static class Events
{
    public static class BuildingEvents
    {
        public static UnityAction<BuildingPlace> onBuildingPlaceSelected = delegate { };
        public static UnityAction<BuildingData> onBuildingConstructionSeleted = delegate { };
        public static UnityAction<Building> onBuildingSpawned = delegate { };
    }

    public static class UI
    {
        public static UnityAction<bool> onBuildingMenuActivenessChanged = delegate { };

    }
}
