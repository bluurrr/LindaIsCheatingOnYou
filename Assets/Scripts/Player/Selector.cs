using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Selector : MonoBehaviour
{
    public Player player;  
    public NavMeshAgent agent; 
    private Camera cam;
    private LayerMask layerMask = ~(1 << 2);


    private InteractableObject selectedObject; 
    void Awake()
    {
        cam = Camera.main;
    }
    public void Select()
    {
        if(Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
        {
            if(UIManager.Instance.WordUICheck()) return; 
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit, float.MaxValue, layerMask))
            {
                Click(hit);
            }
        }

    }

    private void Investigate(InteractableObject obj)
    {
        if(!obj) return;
        obj.Investigate(player);
    }

    private void Click(RaycastHit hit)
    {
        if(Input.GetMouseButtonDown(0))
        {
            if(hit.transform.CompareTag(Consts.TAG_FLOOR))
            {
                agent.SetDestination(hit.point);
                return;
            }
        }
        else if(Input.GetMouseButtonDown(1))
        {
            if(hit.transform.CompareTag(Consts.TAG_INTERACTABLE_OBJECT))
            {
                InteractableObject interactableObject = hit.transform.GetComponent<InteractableObject>();
                Investigate(interactableObject);
                return;
            }
            if(hit.transform.CompareTag(Consts.TAG_FLOOR))
            {
                UIManager.Instance.PopulateActionsMenu(player.actionsManager.GetFloorActions(), Input.mousePosition);
                return;
            }
        }


    }

}
