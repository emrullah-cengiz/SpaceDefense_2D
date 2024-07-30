using System;
using System.Collections;
using UnityEngine;

[Serializable]
public class DamageOverTimeEffectDefinition : EffectDefinitionBase
{
    public int DamagePerSecond;
    public int MaxTargetCount;
}
