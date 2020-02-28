using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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

    public bool CanPlayerInteract(Player player, out Player interactablePlayer) 
    {
        float minDist = .05f;
        foreach(Player p in players)
        {
            if(p != player)
            {
                if(Vector3.Distance(player.iKAnimationManager.GetIKPoint(InteractionTarget.IK_Point_Player.Static_Front).position, p.iKAnimationManager.GetIKPoint(InteractionTarget.IK_Point_Player.Static_Front).position) <= minDist)
                {
                    interactablePlayer = p; 
                    return true;
                }
            }
        }
        interactablePlayer = null; 
        return false;
    }
}
