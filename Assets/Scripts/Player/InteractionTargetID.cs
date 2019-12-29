using System.Collections;
using System.Collections.Generic;
using RootMotion.FinalIK;
using UnityEngine;

public class InteractionTargetID : MonoBehaviour
{
     public enum Owner{player, other}; 
     public Owner target; 
     public InteractionTarget interactionTarget;
     public enum IK_Point_Player{Back_Shoulder_Left, Back_Shoulder_Right, None};
     public IK_Point_Player attachmentID; 
}
