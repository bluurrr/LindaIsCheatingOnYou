using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RootMotion.FinalIK;
using PlayerComponents;
using UnityEngine.Events;

public class IKAnimationManager : MonoBehaviour
{
    public Player player;
    public GameObject ModelRoot; 
    public FullBodyBipedIK fullBodyBipedIK;
    public InteractionSystem interactionSystem;
    public Transform ikSpawn, headspawn;
    public IKAnimationDatabank iKAnimationDatabank;
    public Pose currentPose;
    public EmoteManager emoteManager;
    public PlayerInteractionManager playerInteractionManager;
    private Dictionary<InteractionTarget.IK_Point_Player, Transform> interactionTargets =  new Dictionary<InteractionTarget.IK_Point_Player, Transform>();


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
        if(currentPose == null) return;
        currentPose.RunAnim(fullBodyBipedIK);
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
            playerInteractionManager.SetOfferEmote(ikObj.offerAnimation);
        }

        if(PlayersManager.Instance.CanPlayerInteract(player,out otherPlayer))
        {
            foreach(var point in ikObj.playerInteractionTargets)
            {
                Transform playerPoint = otherPlayer.iKAnimationManager.GetIKPoint(point.playerPoint);
                pose.targetDictionary[point.effector].transform.SetParent(playerPoint);
                pose.targetDictionary[point.effector].transform.localPosition = new Vector3(0,0,0);
            }
        }

        UnityAction emoteAction = emoteManager.GetEmoteAction(ikObj.iD);
        if(emoteAction != null) emoteAction.Invoke();

        currentPose = pose; 
    }

    public IKAnimation GetIKAnim(IKAnimation.IK_Animation_ID id)
    {
       return iKAnimationDatabank.GetAnimation(id);
    }
    public void StopEmote()
    {
        if(currentPose == null) return;
        currentPose.StopAnim(fullBodyBipedIK);
        currentPose = null;
        ClearIKPoses();
    }
    private void ClearIKPoses()
    {
        foreach(Transform emote in ikSpawn)
        {
            Destroy(emote.gameObject);
        }
    }







}
