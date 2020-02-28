using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.AI;
using Level;

public class InteractableObject : MonoBehaviour
{
    public NavMeshObstacle navMeshObject;
    public Outline outline; 
    public Collider collider;
    public float useDistance = 1.5f;
    public bool debug; 
    protected List<Action> actions = new List<Action>();
    private bool inUse;

    public void Awake()
    {
        outline.enabled = false;
    }
    public void Hover()
    {
        outline.enabled = true;
    }
    public void Unhover()
    {
        outline.enabled = false;
    }
    public bool CanInteract(Player player)
    {
        if(debug) print("TRACKING: " + gameObject.name + " is " + Vector3.Distance(transform.position, player.transform.position) + " from " + player.gameObject.name + ". Use dist: "+ useDistance);
        return Vector3.Distance(transform.position, player.transform.position) <= useDistance;
    }

    public virtual void Investigate(Player player)
    {
        UIManager.Instance.PopulateActionsMenu(actions, Input.mousePosition);
    } 

    protected virtual void InteractionCompete()
    {
        actions.Clear();
        UIManager.Instance.TurnOffActionMenu();
    }

    // protected IEnumerator UseSequence(Player player)
    // {
    //     inUse = true;
    //     yield return player.SetDestinationAndFace(GetValidUsePosition(player.agent.transform.position));
    // }   
}
