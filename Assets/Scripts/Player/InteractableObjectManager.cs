using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObjectManager : MonoBehaviour
{
     public Player player;
     public EmotionManager emotionManager;
     public AnimManager animManager;
     private bool _canInteractWithObjects;
     private List<InteractableObject> _interactables; 
     private InteractableObject _objectInUse; 

     public void Init(List<InteractableObject> interactables)
     {
         _interactables = interactables;
         SetCanInteract(true); 
     }

     public void Run()
     {
         if(_interactables.Count == 0 || !_canInteractWithObjects) return; 
         foreach (var item in _interactables)
         {
             if(item.CanInteract(player))
             {
                if(!_objectInUse) animManager.ChangeToInteract();
                Use(item);
             }
             else
             {
                if(!_objectInUse)emotionManager.SetMovementStyleToCurrentMood();
             }
         }
         Cancel();
     }
     public bool UsingObject()
     {
         return _objectInUse;
     }
     public void SetCanInteract(bool canInteract)
     {
         _canInteractWithObjects = canInteract; 
     }


     private void Use(InteractableObject item)
     {
         if(Input.GetButtonDown("A")) 
         {
            item.Use(player);
            _objectInUse = item;
         }
     }

     private void Cancel()
     {
         if(!_objectInUse) return;
         if(Input.GetButtonDown("B")) 
         {
            _objectInUse.Cancel(player);
            _objectInUse = null;
            _canInteractWithObjects = true;
         }
     }
}
