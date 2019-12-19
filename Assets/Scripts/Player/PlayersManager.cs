using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayerComponents;
using Singletons;

public class PlayersManager : UnityInSceneSingleton<PlayersManager>
{
    Player[] players;
    public void Init()
    {
        players = FindObjectsOfType(typeof(Player)) as Player[];
    }

    public Player GetActivePlayer()
    {
        return players[0];
    }
}
