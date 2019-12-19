using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelManager", menuName = "ScriptableObjects/LevelManager")]
public class LevelManager : ScriptableObject
{
    public LevelData[] allLevels; 

    public LevelData GetRandomLevel()
    {
        return allLevels[Random.Range(0,allLevels.Length)];
    }
     
}
