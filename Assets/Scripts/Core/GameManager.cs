using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Transform mapSpawn;
    public ActionDataBank actionDataBank;
    public LevelDataBase levelManager;
    public PlayersManager playerManager;
    public EmoteMenu emoteMenu;
    private LevelData currentLevel; 

    void Awake()
    {
        Init();
    }

    private void Init()
    {
        playerManager.Init();
        actionDataBank.Init();
        emoteMenu.Init(); 
        currentLevel = levelManager.GetRandomLevel();
        Instantiate(currentLevel.map, mapSpawn.transform.position, currentLevel.map.transform.rotation, mapSpawn); 
    }
}
