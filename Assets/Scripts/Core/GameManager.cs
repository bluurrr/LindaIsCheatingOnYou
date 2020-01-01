using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Transform mapSpawn;
    public ActionDataBank actionDataBank;
    public CharacterDataBank characterDataBank; 
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
        characterDataBank.Init();
        playerManager.Init();
        actionDataBank.Init();
        emoteMenu.Init(); 

        currentLevel = levelManager.GetRandomLevel();
        Instantiate(currentLevel.map, mapSpawn.transform.position, currentLevel.map.transform.rotation, mapSpawn); 
        PopulatePlayers(currentLevel);
    }

    private void PopulatePlayers(LevelData levelData)
    {
        CharacterSpawn[] spawnPoints = FindObjectsOfType<CharacterSpawn>();
        List<CharacterSpawn> lindaSpawnPoints = new List<CharacterSpawn>();
        List<CharacterSpawn> jamieSpawnPoints = new List<CharacterSpawn>();

        foreach(CharacterSpawn spawn in spawnPoints)
        {
            if(spawn.neutralSpawn || spawn.character == CharacterDataBank.Characters.jamie)
            {
                jamieSpawnPoints.Add(spawn);
            }
            if(spawn.neutralSpawn || spawn.character == CharacterDataBank.Characters.linda)
            {
                lindaSpawnPoints.Add(spawn);
            }
        }

        Vector3 lindaSpawn = lindaSpawnPoints[Random.Range(0, lindaSpawnPoints.Count)].transform.position;
        Vector3 jamieSpawn = jamieSpawnPoints[Random.Range(0, jamieSpawnPoints.Count)].transform.position;
        Instantiate(characterDataBank.GetCharacter(CharacterDataBank.Characters.jamie), jamieSpawn, characterDataBank.GetCharacter(CharacterDataBank.Characters.jamie).transform.rotation);
        Instantiate(characterDataBank.GetCharacter(CharacterDataBank.Characters.linda), lindaSpawn, characterDataBank.GetCharacter(CharacterDataBank.Characters.linda).transform.rotation);
    }
}
