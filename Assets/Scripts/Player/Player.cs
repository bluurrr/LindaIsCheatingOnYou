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
        public LineOfSight lineOfSight;
        public Selector selector;
        public NavMeshAgent agent;
        public IKAnimationManager iKAnimationManager;
        public EmotionManager emotionManager;

    
        public void Init(PlayerLoudOut loudOut)
        {
            animManager.Init();
            iKAnimationManager.Init();
            emotionManager.Init(loudOut);
        }
        private void Update()
        {
            animManager.WalkingAnimations();
            iKAnimationManager.Run();
            lineOfSight.Look(); 
            selector.Select();
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
    }

}
