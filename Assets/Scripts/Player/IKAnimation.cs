using System.Collections;
using System.Collections.Generic;
using RootMotion.FinalIK;
using UnityEngine;

[System.Serializable]
public class IKAnimation 
{
    public string name;
    public enum IK_Animation_ID {kiss_offer, hug_hugging, hug_offer};
    public IK_Animation_ID iD; 
    public GameObject prefab;
    public Sprite icon;
    public FullBodyBipedEffector[] effectors; 
    public ReactionEvent[] reactions;
    public EffectorToPlayerInteractionTarget[] playerInteractionTargets;
}
