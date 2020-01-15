using System.Collections;
using System.Collections.Generic;
using RootMotion.FinalIK;
using UnityEngine;

public class InteractionTarget : MonoBehaviour
{
     public enum IK_Point_Player{Butt_Right, Arm_UnderArm_Left, Head_Above,None};
     public IK_Point_Player attachmentID;
}
