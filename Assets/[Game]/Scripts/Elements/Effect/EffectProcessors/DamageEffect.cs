using System.Collections;
using UnityEngine;

public class DamageEffect : EffectBase
{
    DamageEffectDefinition _tempEffectDefinition;
    BuildingManager _temp;
    public DamageEffect(DamageEffectDefinition effectDefinition, BuildingManager temp) : base(effectDefinition)
    {
        _tempEffectDefinition = effectDefinition;
        _temp = temp;
    }

    public override void Initialize()
    {
        _temp.StartCoroutine(Fire());
    }

    public override void Execute()
    {

    }

    IEnumerator Fire()
    {
        while (true)
        {
            yield return new WaitForSeconds(1 / _tempEffectDefinition.FireRate);

            Debug.Log("fire " + _tempEffectDefinition.Damage); 
        }
    }
}
