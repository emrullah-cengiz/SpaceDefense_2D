using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Level", fileName = "LevelData")]
public class LevelData : ScriptableObject
{
    public List<WaveData> Waves;
}

[Serializable]
public class WaveData
{
    public short CoolDownAfterLastWave;

    public List<EnemyData> Enemies;
}
