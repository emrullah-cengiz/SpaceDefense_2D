using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class BuildingMenuOptionUI : MonoBehaviour
{
    [SerializeField] private Image _icon;

    private BuildingData _data;

    internal void Setup(BuildingData data)
    {
        _data = data;

        _icon.sprite = data.Sprite;
    }

    public void OnClick()
    {
        Events.BuildingEvents.onBuildingConstructionSeleted?.Invoke(_data);
    }
}
