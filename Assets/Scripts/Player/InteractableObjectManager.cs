using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObjectManager : MonoBehaviour
{
     public Player player;
     public EmotionManager emotionManager;
     public AnimManager animManager;
     private bool _canInteractWithObjects;
     public InteractableObject _objectInUse;
     private MapManager _mapManager;

     public void Init(MapManager mapManager)
     {
         _mapManager = mapManager;
         SetCanInteract(true); 
     }

     public void Run()
     {
         if(_objectInUse)
         {
            Use(_objectInUse);
            Cancel();
         }
         else
         {
            if(_mapManager.interactables.Count == 0) return;
            InteractableObject item = null;

            foreach (var interactable in _mapManager.interactables)
            {
                if(interactable.CanInteract(player))
                {
                    print("setting item in can interact: " + interactable.transform.name);
                    item = interactable;
                }
            }
            if(item) 
            {
                animManager.ChangeToInteract();
                Use(item);
            }
            else
            {
                emotionManager.SetMovementStyleToCurrentMood();               
            } 
         }

     }
     public bool UsingObject()
     {
         return _objectInUse;
     }
     public void SetCanInteract(bool canInteract)
     {
         _canInteractWithObjects = canInteract; 
     }
     public void SetObjectInUse(InteractableObject item)
     {
         print("setting object in use to: " + item.transform.name);
         _objectInUse = item;
     }
     private void Use(InteractableObject item)
     {
         if(Input.GetButtonDown("A")) 
         {
            _objectInUse = item;
            item.Use(player);
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
