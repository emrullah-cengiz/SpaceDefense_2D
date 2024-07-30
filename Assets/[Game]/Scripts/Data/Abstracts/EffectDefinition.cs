using System;
using System.Collections;
using UnityEngine;

[Serializable]
public abstract class EffectDefinitionBase : IEffectDefinition
{
    [SerializeField] private Bullet _bulletPrefab;
    public Bullet BulletPrefab { get => _bulletPrefab; set => _bulletPrefab = value; }

    public int BarrelNumber;
}
