using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RootMotion.FinalIK;

[System.Serializable]
public class EffectorToPlayerInteractionTarget 
{
    public string name;
    public FullBodyBipedEffector effector;
    public InteractionTarget.IK_Point_Player playerPoint;
}
