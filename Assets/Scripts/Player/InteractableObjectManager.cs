using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObjectManager : MonoBehaviour
{
     public Player player;
     public EmotionManager emotionManager;
     public AnimManager animManager;
     private List<InteractableObject> _interactables; 
     private InteractableObject _objectInUse; 

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
                animManager.ChangeToInteract();
                Use(item);
             }
             else
             {
                emotionManager.SetMovementStyleToCurrentMood();
             }
         }
         Cancel();
     }

     private void Use(InteractableObject item)
     {
         if(_objectInUse) return;
         if(Input.GetButtonDown("A")) 
         {
            item.Use(player);
            _objectInUse = item;
         }
     }

     private void Cancel()
     {
         print("is it this");
         if(!_objectInUse) return;
         if(Input.GetButtonDown("B")) 
         {
            print("b is being hit");
            _objectInUse.Cancel(player);
            _objectInUse = null;
         }
     }
}
