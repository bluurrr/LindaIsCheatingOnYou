﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EmoteManager : MonoBehaviour
{
    public Player player;
    public AnimManager animManager;
    Dictionary<IKAnimation.IK_Animation_ID, UnityAction> emoteActions = new Dictionary<IKAnimation.IK_Animation_ID, UnityAction>();

    public void Init()
    {
        emoteActions.Add(IKAnimation.IK_Animation_ID.hug_hugging, Hugging);
    }

    public UnityAction GetEmoteAction(IKAnimation.IK_Animation_ID id)
    {
        if(emoteActions.ContainsKey(id))
        {
            return emoteActions[id];
        }
        return null;
    }

    private void Hugging()
    {
        player.PauseInput_All();
        animManager.SetMovementToIdle();
        SetAsOffered();
    }
    private void SetAsOffered()
    {
        Player otherPlayer;
        if(PlayersManager.Instance.CanPlayerInteract(player, out otherPlayer))
        {
            otherPlayer.playerInteractionManager.SetOfferedPlayer(player);
        }
    }
}
