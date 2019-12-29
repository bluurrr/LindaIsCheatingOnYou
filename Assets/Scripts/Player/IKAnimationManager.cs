using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Singletons;
using RootMotion.FinalIK;

public class IKAnimationManager : MonoBehaviour
{
    public GameObject ModelRoot; 
    public FullBodyBipedIK fullBodyBipedIK;
    private Dictionary<string, Transform> IKPoints =  new Dictionary<string, Transform>();

    public void Init()
    {
        IKPoint[] ikPoints = ModelRoot.GetComponentsInChildren<IKPoint>();
        foreach(IKPoint point in ikPoints)
        {
            IKPoints.Add(point.iD.ToString(), point.transform);
        }
    }

    public Transform GetIKPoint(string key)
    {
        if(IKPoints.ContainsKey(key))
        {
            return IKPoints[key];
        }
        return null;
    }

    public void AssignIKTarget(InteractionTarget interactionTarget, Transform obj)
    {
        switch(interactionTarget.effectorType)
        {
            case RootMotion.FinalIK.FullBodyBipedEffector.RightHand:
                fullBodyBipedIK.solver.rightHandEffector.target = obj;
            break;
            case RootMotion.FinalIK.FullBodyBipedEffector.LeftHand:
                fullBodyBipedIK.solver.leftHandEffector.target = obj;
            break;
            case RootMotion.FinalIK.FullBodyBipedEffector.Body:
                fullBodyBipedIK.solver.bodyEffector.target = obj;
            break;  
        }
        fullBodyBipedIK.solver.leftHandEffector.target = obj; 
    }

}
