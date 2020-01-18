using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace PlayerComponents
{
    public class AnimManager : MonoBehaviour
    {
        public Animator animator;
        public Transform carryAnchor;
        public Movement_XZ movement;
        private const int ANIM_MOVEMENT_IDLE = 0;
        private const int ANIM_MOVEMENT_WALK = 1;
        private const int ANIM_MOVEMENT_RUN = 2;
        private const int STYLE_ID_WALK = 0;
        private const int STYLE_ID_CARRY = 1;


        private const string MOVEMENT_ID = "movementID";
        private const string MOVEMENT_STYLE_ID = "movementStyleID";

        public void Init()
        {
        }

        public void WalkingAnimations()
        {
            if(IsMoving())
            {
                animator.SetInteger(MOVEMENT_ID, ANIM_MOVEMENT_WALK);
                return; 
            }
            animator.SetInteger(MOVEMENT_ID, ANIM_MOVEMENT_IDLE);
        }

        public void ChangeToCarry(Transform obj)
        {
            animator.SetInteger(MOVEMENT_STYLE_ID, STYLE_ID_CARRY);
            obj.transform.SetParent(carryAnchor);
            obj.transform.localPosition = Vector3.zero;
        }
        public void ChangeToWalk()
        {
            animator.SetInteger(MOVEMENT_STYLE_ID, STYLE_ID_WALK);
        }
        public void SetMovementToIdle()
        {
            animator.SetInteger(MOVEMENT_ID, ANIM_MOVEMENT_IDLE);
        }

        private bool IsMoving()
        {
            return movement.IsMoving() != 0;
        }
    }
}

