using System.Collections;
using System.Collections.Generic;
using RootMotion.FinalIK;
using UnityEngine;

public class IKAnimation : MonoBehaviour
{
    private IKAnimationManager iKAnimationManager;
    private InteractionTargetID[] interationcTargetID;
    private List<InteractionTargetID> pinnedTargets = new List<InteractionTargetID>();

    private void Awake()
    {
        Init();
    }
    private void Init()
    {
        iKAnimationManager = GetComponentInParent<IKAnimationManager>();
        interationcTargetID = GetComponentsInChildren<InteractionTargetID>();
        foreach(InteractionTargetID target in interationcTargetID)
        {
            if(target.animationType == InteractionTargetID.AnimationType.pin)
            {
                pinnedTargets.Add(target);
            }
        }  
    }
    public void Play()
    {
        Pin();
    }

    private void Pin()
    {

    }
}
