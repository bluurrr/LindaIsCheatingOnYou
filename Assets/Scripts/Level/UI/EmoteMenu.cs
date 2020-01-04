using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmoteMenu : MonoBehaviour
{
    public GameObject Center; 
    public GameObject EmoteBubblePrefab;
    private int SelectionIndex = -1;
    private Dictionary<int, Transform> SpawnOrderDictionary = new Dictionary<int, Transform>();
    private Camera camera;
    public void Init()
    {
        EmoteButtonSpawn[] spawnPoints = GetComponentsInChildren<EmoteButtonSpawn>();
        foreach(EmoteButtonSpawn emoteButtonSpawn in spawnPoints)
        {
            SpawnOrderDictionary.Add(emoteButtonSpawn.spawnOrder, emoteButtonSpawn.transform);
        }
        Center.SetActive(false);
        camera = Camera.main;
    }

    public void OpenEmoteMenu(EmotionManager emotionManager)
    {
        if(Center.activeSelf) return;

        var emotes = emotionManager.GetCurrentMoodEmotes();
        for(int i = 0; i< emotes.Count; i++)
        {

            GameObject button = Instantiate(EmoteBubblePrefab, SpawnOrderDictionary[i+1].transform);
            button.transform.localPosition = Vector3.zero;
            EmoteBubbleButton emoteBubble = button.GetComponent<EmoteBubbleButton>();
            emoteBubble.SetUp(emotes[i]);
        }
        Center.SetActive(true);
    }

    public void Run(Transform headAnchor)
    {
        //if(!Center.activeSelf) return; 
        Vector3 destination = camera.WorldToScreenPoint(headAnchor.position);
        Center.transform.position = destination; 
        print("head anchor");
    }
}
