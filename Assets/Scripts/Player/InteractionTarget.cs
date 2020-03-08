using System.Collections;
using System.Collections.Generic;
using RootMotion.FinalIK;
using UnityEngine;

public class InteractionTarget : MonoBehaviour
{
     public enum IK_Point_Player{Butt_Right,Butt_Left, Arm_UnderArm_Left, Arm_UnderArm_Right, Head_Above, None, Arm_Shoulder_Front_Left, Arm_Shoulder_Front_Right, Foot_Under_Left, Foot_Under_Right, Object_UnderArm_Left, Object_UnderArm_Right, Object_Front,Static_Front};
     public IK_Point_Player attachmentID;
}
