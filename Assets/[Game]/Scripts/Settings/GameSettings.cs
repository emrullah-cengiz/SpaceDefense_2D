using Sirenix.OdinInspector;
using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Settings")]
public class GameSettings : SerializedScriptableObject
{
    public Vector3 BuildingMenuOffset;
    public Dictionary<BuildingType, Building> _buildingPrefabs;

}
