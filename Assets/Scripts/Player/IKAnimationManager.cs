using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RootMotion.FinalIK;
using PlayerComponents;

public class IKAnimationManager : MonoBehaviour
{
    public Player player;
    public GameObject ModelRoot; 
    public FullBodyBipedIK fullBodyBipedIK;
    public InteractionSystem interactionSystem;
    public Transform ikSpawn, headspawn;
    public IKAnimationDatabank iKAnimationDatabank;
    private Dictionary<InteractionTarget.IK_Point_Player, Transform> interactionTargets =  new Dictionary<InteractionTarget.IK_Point_Player, Transform>();
    public Pose currentPose;
    private IKAnimation _offerAnimation;

    public void Init()
    {
        InteractionTarget[] targets = ModelRoot.GetComponentsInChildren<InteractionTarget>();
        foreach(InteractionTarget point in targets)
        {
            interactionTargets.Add(point.attachmentID, point.transform);
        }
    }

    public void Run()
    {
        OfferEmotes();
        if(currentPose == null) return;
        currentPose.RunAnim(fullBodyBipedIK);
        StopEmote();
    }

    public Transform GetIKPoint(InteractionTarget.IK_Point_Player target)
    {
        if(interactionTargets.ContainsKey(target))
        {
            return interactionTargets[target];
        }
        return null;
    }

    public void PlayEmote(IKAnimation ikObj)
    {
        if((currentPose) && ikObj.iD == currentPose.ID) return;
        ClearIKPoses();
        Pose pose = Instantiate(ikObj.prefab, ikSpawn).GetComponent<Pose>();
        pose.Init();

        Player otherPlayer;
        if(ikObj.offerAnimation != IKAnimation.IK_Animation_ID.none)
        {
            SetOfferEmote(ikObj.offerAnimation);
        }
        else
        {
            _offerAnimation = null; 
        }

        if(PlayersManager.Instance.CanPlayerInteract(player,out otherPlayer))
        {
            foreach(var point in ikObj.playerInteractionTargets)
            {
                Transform playerPoint = otherPlayer.iKAnimationManager.GetIKPoint(point.playerPoint);
                pose.targetDictionary[point.effector].transform.SetParent(playerPoint);
            }
        }


        currentPose = pose; 
    }
    private void StopEmote()
    {
        if(Input.GetButtonDown("B"))
        {
            currentPose.StopAnim(fullBodyBipedIK);
            currentPose = null;
            _offerAnimation = null;
            ClearIKPoses();
        }
    }
    private void ClearIKPoses()
    {
        foreach(Transform emote in ikSpawn)
        {
            Destroy(emote.gameObject);
        }
    }
    private void OfferEmotes()
    {
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
    private void SetOfferEmote(IKAnimation.IK_Animation_ID id)
    { 
        _offerAnimation = iKAnimationDatabank.GetAnimation(id);
    }
    private void PlayOfferAnimation()
    {
        if(_offerAnimation == null) return;
        PlayEmote(_offerAnimation);
    }






}
