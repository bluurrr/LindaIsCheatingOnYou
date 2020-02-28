using System.Collections;
using System.Collections.Generic;
using RootMotion.FinalIK;
using UnityEngine;

public class Pose : MonoBehaviour
{
    RootMotion.FinalIK.InteractionTarget[] targets;
    private bool activeLeftHand, activeRightHand,activeBody;
    public Dictionary<FullBodyBipedEffector, Transform> targetDictionary = new Dictionary<FullBodyBipedEffector, Transform>();
    public IKAnimation.IK_Animation_ID ID; 
    public void Init()
    {
        targets = GetComponentsInChildren<RootMotion.FinalIK.InteractionTarget>();
        foreach(RootMotion.FinalIK.InteractionTarget target in targets)
        {
            switch(target.effectorType)
            {
                case FullBodyBipedEffector.LeftHand:
                    activeLeftHand = true;
                    break;
                case FullBodyBipedEffector.RightHand:
                    activeRightHand = true;
                    break;
                case FullBodyBipedEffector.Body:
                    activeBody = true;
                    break;
            }
            targetDictionary.Add(target.effectorType, target.transform);
        }
    }

    public void RunAnim(FullBodyBipedIK player)
    {
        if(activeLeftHand)
        {
            player.solver.leftHandEffector.position = targetDictionary[FullBodyBipedEffector.LeftHand].position;
            player.solver.leftHandEffector.rotation = targetDictionary[FullBodyBipedEffector.LeftHand].rotation;
            player.solver.leftHandEffector.positionWeight = 1;
            player.solver.leftHandEffector.rotationWeight = 1;
        }
        else
        {
            player.solver.leftHandEffector.positionWeight = 0;
            player.solver.leftHandEffector.rotationWeight = 0;
        }

        if(activeRightHand)
        {
            player.solver.rightHandEffector.position = targetDictionary[FullBodyBipedEffector.RightHand].position;
            player.solver.rightHandEffector.rotation = targetDictionary[FullBodyBipedEffector.RightHand].rotation;
            player.solver.rightHandEffector.positionWeight = 1;
            player.solver.rightHandEffector.rotationWeight = 1;
        }
        else
        {
            player.solver.rightHandEffector.positionWeight = 0;
            player.solver.rightHandEffector.rotationWeight = 0;
        }

        if(activeBody)
        {
            player.solver.bodyEffector.position = targetDictionary[FullBodyBipedEffector.Body].position;
            player.solver.bodyEffector.rotation = targetDictionary[FullBodyBipedEffector.Body].rotation;
            player.solver.bodyEffector.positionWeight = 1;
            player.solver.bodyEffector.rotationWeight = 1;
        }
        else
        {
            player.solver.bodyEffector.positionWeight = 0;
            player.solver.bodyEffector.rotationWeight = 0;
        }
    }

    public void StopAnim(FullBodyBipedIK player)
    {
        if(activeLeftHand)
        {
            player.solver.leftHandEffector.positionWeight = 0;
            player.solver.leftHandEffector.rotationWeight = 0;
        }
        if(activeRightHand)
        {
            player.solver.rightHandEffector.positionWeight = 0;
            player.solver.rightHandEffector.rotationWeight = 0;
        }
        if(activeBody)
        {
            player.solver.bodyEffector.positionWeight = 0;
            player.solver.bodyEffector.rotationWeight = 0;
        }
    }

}
