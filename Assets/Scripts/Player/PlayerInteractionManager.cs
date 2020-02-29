using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractionManager : MonoBehaviour
{
    public Player player;
    public IKAnimationManager iKAnimationManager;
    public EmotionManager emotionManager;
    public Player _offeredPlayer;
    private IKAnimation _offerAnimation;
    private float _offeredDistBreak = 1; 


    public void Run()
    {
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
            string otherPlayerKey = _offeredPlayer.iKAnimationManager.currentPose.ID + "_" + CustomReaction.Outcome.rejected_soft;
            string playerKey = _offeredPlayer.iKAnimationManager.currentPose.ID + "_" + CustomReaction.Outcome.rejecting_soft;
            _offeredPlayer.emotionManager.PlayCustomReaction(otherPlayerKey);
            emotionManager.PlayCustomReaction(playerKey);
            StopOffered();
        }
        StopOfferedListen();
    }
    private void OfferEmotes()
    {
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
        if(_offerAnimation == null)return;
        if(Input.GetButtonDown("B"))
        {
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
            print("rejected hard");
            string otherPlayerKey = _offeredPlayer.iKAnimationManager.currentPose.ID + "_" + CustomReaction.Outcome.rejected_hard;
            string playerKey = _offeredPlayer.iKAnimationManager.currentPose.ID + "_" + CustomReaction.Outcome.rejecting_hard;
            _offeredPlayer.emotionManager.PlayCustomReaction(otherPlayerKey);
            emotionManager.PlayCustomReaction(playerKey);
            StopOffered(); 
        }
    }

    public void StopOffered()
    {
        if(_offeredPlayer)
        {
            StopEmote();
            _offeredPlayer.playerInteractionManager.StopOffer();
            _offeredPlayer = null;
        }    
    }

    private bool OfferedDistBreak()
    {
        return Vector3.Distance(transform.position, _offeredPlayer.transform.position) > _offeredDistBreak;
    }
}
