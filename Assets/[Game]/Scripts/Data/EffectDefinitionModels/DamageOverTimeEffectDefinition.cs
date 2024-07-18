using System;
using System.Collections;
using UnityEngine;

[Serializable]
public class DamageOverTimeEffectDefinition : EffectDefinition
{
    public int DamagePerSecond;
    public int MaxTargetCount;
}
