using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public static class Events
{
    public static class BuildingEvents
    {
        public static UnityAction<BuildingPlace> onBuildingPlaceSelected = delegate { };
        public static UnityAction<BuildingType, BuildingPlace> onBuildingConstructionSeleted = delegate { };
    }
}
