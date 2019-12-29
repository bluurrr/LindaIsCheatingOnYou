using System.Collections;
using System.Collections.Generic;
using RootMotion.FinalIK;
using UnityEngine;

[System.Serializable]
public class IKAnimation 
{
    public string name;
    public enum IK_Animation_ID {kiss, hug};
    public IK_Animation_ID iD; 
    public GameObject interactionObject;
}
