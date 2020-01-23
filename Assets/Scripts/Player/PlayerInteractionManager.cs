using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayerComponents;

public class PlayerInteractionManager : MonoBehaviour
{
    public Player player;
    public IKAnimationManager iKAnimationManager;
    public Player _offeredPlayer;
    private IKAnimation _offerAnimation;
    private float _offeredDistBreak = 1;


    public void Run()
    {
        print("run");
        OfferEmotes();
        OfferedEmote();
    }
    public void SetOfferEmote(IKAnimation.IK_Animation_ID id)
    { 
        _offerAnimation = iKAnimationManager.GetIKAnim(id);
    }
    public void SetOfferedPlayer(Player player)
    {
        _offeredPlayer = player;
    }
    private void OfferedEmote()
    {
        if(_offeredPlayer == null) return;

        if(OfferedDistBreak())
        {
            StopOffered();
        }
        StopOfferedListen();
    }
    private void OfferEmotes()
    {
        print("offer emote");
        StopOfferListen();

        if(_offerAnimation == null) return;
        Player otherPlayer;
        if(OfferEmoteTriggered(out otherPlayer))
        {
            PlayOfferAnimation();
        }
    }
    private bool OfferEmoteTriggered(out Player otherPlayer)
    {   
        return PlayersManager.Instance.CanPlayerInteract(player, out otherPlayer);
    }

    private void PlayOfferAnimation()
    {
        iKAnimationManager.PlayEmote(_offerAnimation);
    }

    private void StopOfferListen()
    {
        if(Input.GetButtonDown("B"))
        {
            print("pressing b");
            StopOffer();
        }
    }

    public void StopOffer()
    {
        StopEmote();
        _offerAnimation = null; 
    }

    private void StopEmote()
    {
        iKAnimationManager.StopEmote();
        player.EnableInput_All();
    }

    private void StopOfferedListen()
    {
        if(Input.GetButtonDown("B"))
        {
            StopOffered();
        }
    }

    public void StopOffered()
    {
        if(_offeredPlayer)
        {
            _offeredPlayer = null;
            StopEmote();
            _offeredPlayer.playerInteractionManager.StopOffer();
        }    
    }

    private bool OfferedDistBreak()
    {
        return Vector3.Distance(transform.position, _offeredPlayer.transform.position) > _offeredDistBreak;
    }
}
