using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Enemy", fileName = "EnemyData")]
public class EnemyData : ScriptableObject
{
    public string Name;
    public float Speed = 1;
    public short Health = 10;
    public float Armor = 0;
}
