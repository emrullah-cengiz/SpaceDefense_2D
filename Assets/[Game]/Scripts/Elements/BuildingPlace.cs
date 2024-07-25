using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BuildingPlace : MonoBehaviour
{
    public void OnMouseDown()
    {
        Events.BuildingEvents.onBuildingPlaceSelected?.Invoke(this);
    }

    public void Enable(bool s) => gameObject.SetActive(s);
}
