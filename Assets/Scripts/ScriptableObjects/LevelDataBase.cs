using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelDataBase", menuName = "ScriptableObjects/LevelDataBase")]
public class LevelDataBase : ScriptableObject
{
    public LevelData[] allLevels; 

    public LevelData GetRandomLevel()
    {
        return allLevels[Random.Range(0,allLevels.Length)];
    }
     
}
