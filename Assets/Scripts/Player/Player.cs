using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using DG.Tweening;

namespace PlayerComponents
{
    public class Player : MonoBehaviour
    {
        public enum Characters{Linda, Tim, Jimmy, Mark};
        public Characters thisCharacter;
        public float walkSpeed, runSpeed;
        public AnimManager animManager;
        public ActionsManager actionsManager;
        public NavMeshAgent agent;
        public IKAnimationManager iKAnimationManager;
        public EmotionManager emotionManager;
        public Movement_XZ movement_XZ;
        public Transform frontAnchor;
        public EmoteManager emoteManager;
        public PlayerInteractionManager playerInteractionManager;
        public bool TestingDisable;

        private bool _pauseInput;


    
        public void Init(PlayerLoudOut loudOut)
        {
            animManager.Init();
            iKAnimationManager.Init();
            emotionManager.Init(loudOut);
            emoteManager.Init();
        }
        private void Update()
        {
            Run();
        }

        private void Run()
        {
            iKAnimationManager.Run();
            playerInteractionManager.Run();
            if(TestingDisable) return;
            if(_pauseInput) return; 
            movement_XZ.Movement();
            animManager.WalkingAnimations();
            UIManager.Instance.RunEmoteMenu(iKAnimationManager.headspawn);
        }

        private void SetDestination(Vector3 destination)
        {
            agent.SetDestination(destination);
        }

        public IEnumerator SetDestinationAndFace(Vector3 destination)
        {
            agent.SetDestination(destination);
            yield return new WaitUntil(()=> Vector3.Distance(agent.transform.position, destination) < 1);
            agent.transform.DOLookAt(transform.position, 1, AxisConstraint.Y, Vector3.up);
            yield return new WaitForSeconds(1);
        }

        public void OpenEmoteMenu()
        {
            UIManager.Instance.emoteMenu.OpenEmoteMenu(emotionManager);
        }

        public void CloseEmoteMenu()
        {
            UIManager.Instance.emoteMenu.CloseEmoteMenu();    
        }

        public void PauseInput_All()
        {
            _pauseInput = true; 
        }
        public void EnableInput_All()
        {
            _pauseInput = false; 
        }
    }

}
