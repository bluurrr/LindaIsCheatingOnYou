using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

    public class AnimManager : MonoBehaviour
    {
        public Animator animator;
        public Movement_XZ movement;
        public ParticleSystemManager particleSystemMananger;
        public IKAnimationManager ikAnimationManager;
        private const int ANIM_MOVEMENT_IDLE = 0;
        private const int ANIM_MOVEMENT_WALK = 1;
        private const int ANIM_MOVEMENT_RUN = 2;
        private const int STYLE_ID_NEUTRAL = 0;
        private const int STYLE_ID_CARRY = 1;
        private const int STYLE_ID_SAD = 2;
        private const int STYLE_ID_ANGRY = 3;
        private const int STYLE_ID_INTERACT = 4;
        private const int STYLE_ID_CARRY_UNERARM = 5;
        private const string MOVEMENT_ID = "movementID";
        private const string MOVEMENT_STYLE_ID = "movementStyleID";
        private const string TRIGGER_GRAB_UNDERARM = "grabUnderarm";


        public void Init()
        {
        }

        public void WalkingAnimations()
        {
            if(IsMoving())
            {
                animator.SetInteger(MOVEMENT_ID, (movement.IsRunning()) ? ANIM_MOVEMENT_RUN : ANIM_MOVEMENT_WALK);
                return; 
            }
            animator.SetInteger(MOVEMENT_ID, ANIM_MOVEMENT_IDLE);
        }

        public void ChangeToCarry(Transform obj)
        {
            animator.SetInteger(MOVEMENT_STYLE_ID, STYLE_ID_CARRY);
            obj.transform.SetParent(ikAnimationManager.GetIKPoint(InteractionTarget.IK_Point_Player.Object_Front));
            obj.transform.localPosition = Vector3.zero;
        }
        public void ChangeToCarryUnderArm(Transform obj)
        {
            animator.SetInteger(MOVEMENT_STYLE_ID, STYLE_ID_CARRY_UNERARM);
            obj.transform.SetParent(ikAnimationManager.GetIKPoint(InteractionTarget.IK_Point_Player.Object_UnderArm_Left));
            obj.transform.localPosition = Vector3.zero;
        }
        public void ChangeToInteract()
        {
            animator.SetInteger(MOVEMENT_STYLE_ID, STYLE_ID_INTERACT);
        }
        public void ChangeToWalkNeutral()
        {
            animator.SetInteger(MOVEMENT_STYLE_ID, STYLE_ID_NEUTRAL);
        }
        public void ChangeToWalkSad()
        {
            animator.SetInteger(MOVEMENT_STYLE_ID, STYLE_ID_SAD);
        }
        public void ChangeToWalkAngry()
        {
            animator.SetInteger(MOVEMENT_STYLE_ID, STYLE_ID_ANGRY);
        }
        public void SetMovementToIdle()
        {
            animator.SetInteger(MOVEMENT_ID, ANIM_MOVEMENT_IDLE);
        }

        public void Grab_Underarm()
        {
            animator.SetTrigger(TRIGGER_GRAB_UNDERARM);
        }

        private bool IsMoving()
        {
            return movement.IsMoving() != 0;
        }

        public void PlayerLeftWalkPS()
        {
            particleSystemMananger.PlayParticle(ParticleSystemObject.Type.poof, InteractionTarget.IK_Point_Player.Foot_Under_Left);
        }
        
        public void PlayerRightWalkPS()
        {
            particleSystemMananger.PlayParticle(ParticleSystemObject.Type.poof, InteractionTarget.IK_Point_Player.Foot_Under_Right);
        }
    }

