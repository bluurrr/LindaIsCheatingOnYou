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
        ClearIKPoses();
        Pose pose = Instantiate(ikObj.prefab, ikSpawn).GetComponent<Pose>();
        pose.Init();
        print("pose init ");

        foreach(var reaction in ikObj.reactions)
        {
            switch(reaction.iK_Animation_ID)
            {
                case IKAnimation.IK_Animation_ID.hug_hugging:
                print("found this reaction " + reaction.triggerEvent.ToString());
                //EventManager.StartListening(reaction.triggerEvent.ToString(), Play_Hugging);
                break;  
            }
        }
        print("player interact ");

        Player otherPlayer;
        if(PlayersManager.Instance.CanPlayerInteract(player,out otherPlayer))
        {
            print("if pass ");

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

    private void Play_Hugging()
    { 
        print("current pose: " + currentPose.ID);
        if(currentPose.ID == IKAnimation.IK_Animation_ID.hug_hugging) return;
        print("after return ");
        IKAnimation animation = iKAnimationDatabank.GetAnimation(IKAnimation.IK_Animation_ID.hug_hugging);
        print("after animation ");
        PlayEmote(animation);
        print("after play ");

        //EventManager.StopListening(Consts.Events.playerCanInteract.ToString(), Play_Hugging);
    }




}
