using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.AI;
using Level;

public abstract class InteractableObject : MonoBehaviour
{
    public NavMeshObstacle navMeshObject;
    public Collider collider;
    public float useDistance = 1.5f;
    public bool debug; 
    protected List<Action> actions = new List<Action>();

    public bool CanInteract(Player player)
    {
        if(debug) print("TRACKING: " + gameObject.name + " is " + Vector3.Distance(transform.position, player.transform.position) + " from " + player.gameObject.name + ". Use dist: "+ useDistance);
        return Vector3.Distance(transform.position, player.transform.position) <= useDistance;
    }

    public virtual void Investigate(Player player)
    {
        UIManager.Instance.PopulateActionsMenu(actions, Input.mousePosition);
    } 

    public abstract void Use(Player player);
    public abstract void Cancel(Player player);

}
