using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayerComponents;
using DG.Tweening;
using UnityEngine.AI;
using Level;

public class InteractableObject : MonoBehaviour
{
    public NavMeshObstacle navMeshObject;
    public Outline outline; 
    public Collider collider; 
    protected List<Action> actions = new List<Action>();
    private bool inUse;
    private const float USE_DISTANCE = 1.5f;

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
        return Vector3.Distance(transform.position, player.transform.position) <= USE_DISTANCE;
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
