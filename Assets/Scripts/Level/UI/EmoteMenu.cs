using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmoteMenu : MonoBehaviour
{
    public GameObject Center; 
    public GameObject EmoteBubblePrefab;
    private EmoteButtonSpawn[] spawnPoints;

    public void Init()
    {
        spawnPoints = GetComponentsInChildren<EmoteButtonSpawn>();
    }

    public void OpenEmoteMenu()
    {

    }
}
