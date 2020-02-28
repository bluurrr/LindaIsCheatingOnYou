using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObjectManager : MonoBehaviour
{
     public Player player;
     public EmotionManager emotionManager;
     public AnimManager animManager;
     private List<InteractableObject> _interactables; 

     public void Init(List<InteractableObject> interactables)
     {
         _interactables = interactables;
     }

     public void Run()
     {
         if(_interactables.Count == 0) return; 
         foreach (var item in _interactables)
         {
             if(item.CanInteract(player))
             {
                print("can interact");
                animManager.ChangeToInteract();
             }
             else
             {
                print("cannot interact");
                emotionManager.SetMovementStyleToCurrentMood();
             }
         }
     }
}
