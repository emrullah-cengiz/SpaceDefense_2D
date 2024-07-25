using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Building", fileName = "BuildingData")]
public class BuildingData : SerializedScriptableObject
{
    [PreviewField]
    public Sprite Sprite;
    
    public string Name;

    public BuildingType Type;

    public int Price;

    //public List<EffectDefinition> EffectDefinitions;

    public EffectDefinition EffectDefinition;
}
