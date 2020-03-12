using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Singletons;
using Cinemachine;
using System.Linq;

public class GameManager : UnityInSceneSingleton<GameManager>
{
    public Transform mapSpawn;
    public ActionDataBank actionDataBank;
    public CharacterDataBank characterDataBank; 
    public ParticleSystemDataBank particleSystemDataBank;
    public LevelDataBase levelManager;
    public PlayersManager playerManager;
    public EmoteMenu emoteMenu;
    public IKAnimationDatabank iKAnimationDatabank;
    public CinemachineTargetGroup cinemachineTargetGroup;
    private LevelData currentLevel; 
    private Dictionary<CharacterDataBank.Characters, Player> playerDictionary = new Dictionary<CharacterDataBank.Characters, Player>();
    private MapManager mapManager;

    new void Awake()
    {
        Init();
        SpawnLevel();
        PopulateLevel();
    }
    private void Init()
    {
        iKAnimationDatabank.Init();
        characterDataBank.Init();
        particleSystemDataBank.Init();
        actionDataBank.Init();
        emoteMenu.Init(); 
    }

    private void SpawnLevel()
    {
        currentLevel = levelManager.GetRandomLevel();
        GameObject map = Instantiate(currentLevel.map, mapSpawn.transform.position, currentLevel.map.transform.rotation, mapSpawn); 
        mapManager = map.GetComponent<MapManager>();
    }

    private void PopulateLevel()
    {
        PopulatePlayers();
        PopulatePlayerLoudouts();
    }

    private void PopulatePlayers()
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
        GameObject jamie = Instantiate(characterDataBank.GetCharacter(CharacterDataBank.Characters.jamie), jamieSpawn, characterDataBank.GetCharacter(CharacterDataBank.Characters.jamie).transform.rotation);
        GameObject linda = Instantiate(characterDataBank.GetCharacter(CharacterDataBank.Characters.linda), lindaSpawn, characterDataBank.GetCharacter(CharacterDataBank.Characters.linda).transform.rotation);
        AddCameraTarget(jamie.transform);
        AddCameraTarget(linda.transform);
        playerDictionary.Add(CharacterDataBank.Characters.jamie, jamie.GetComponent<Player>());
        playerDictionary.Add(CharacterDataBank.Characters.linda, linda.GetComponent<Player>());
        playerManager.Init();
    }

    private void AddCameraTarget(Transform trans)
    {
        var target = new CinemachineTargetGroup.Target {target = trans, radius = 1, weight = 1}; 
        var tempList = cinemachineTargetGroup.m_Targets.ToList();
        tempList.Add(target);        
        cinemachineTargetGroup.m_Targets = tempList.ToArray();
    }

    private void PopulatePlayerLoudouts()
    {
        foreach(PlayerLoudOut loudOut in currentLevel.playerLoudOuts)
        {
            if(playerDictionary.ContainsKey(loudOut.character))
            {
                playerDictionary[loudOut.character].Init(loudOut, mapManager.interactables, mapManager);
            }
        }
    }


}
