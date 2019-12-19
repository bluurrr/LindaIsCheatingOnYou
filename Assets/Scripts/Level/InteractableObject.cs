using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayerComponents;
using DG.Tweening;
using UnityEngine.AI;
using Level;

public class InteractableObject : MonoBehaviour
{
    public enum Type{pickUp, none}
    public Type type;
    public enum AutoUsePositionMode{none, square};
    public AutoUsePositionMode autoUsePosMode;
    public NavMeshObstacle navMeshObject;
    public List<Transform> customUsePositions = new List<Transform>();
    public Outline outline; 
    public Collider collider; 
    protected List<Action> actions = new List<Action>();
    private bool inUse;
    private const float MIN_USE_DIST = .5f; 

    public void Awake()
    {
        outline.enabled = false;
    }
    private List<Vector3> AllUsePositions()
    {
        List<Vector3> allUsePositions = new List<Vector3>();
        switch (autoUsePosMode)
        {
            case AutoUsePositionMode.square:
                allUsePositions.AddRange(SquareAutoUsePositions());
            break;
        }
        foreach(Transform pos in customUsePositions)
        {
            allUsePositions.Add(pos.position);
        }
        return allUsePositions;
    }
    public void Hover()
    {
        outline.enabled = true;
    }

    public void Unhover()
    {
        outline.enabled = false;
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

    protected IEnumerator UseSequence(Player player)
    {
        inUse = true;
        yield return player.SetDestinationAndFace(GetValidUsePosition(player.agent.transform.position));
    } 
    private List<Vector3> SquareAutoUsePositions()
    {
        List<Vector3> autoUsePositions = new List<Vector3>();
        float distCheck = transform.localScale.sqrMagnitude + 10;
        autoUsePositions.Add(collider.ClosestPointOnBounds(transform.position + (Vector3.left * distCheck)) + (Vector3.left * MIN_USE_DIST));
        autoUsePositions.Add(collider.ClosestPointOnBounds(transform.position + (Vector3.right * distCheck)) + (Vector3.right * MIN_USE_DIST));
        autoUsePositions.Add(collider.ClosestPointOnBounds(transform.position + (Vector3.forward * distCheck)) + (Vector3.forward * MIN_USE_DIST));
        autoUsePositions.Add(collider.ClosestPointOnBounds(transform.position + (Vector3.back * distCheck)) + (Vector3.back * MIN_USE_DIST));
        return autoUsePositions;
    }
    private Vector3 GetValidUsePosition(Vector3 otherObj)
    {
        float minDist = float.MaxValue;
        Vector3 destination = Vector3.zero;
        foreach(Vector3 pos in AllUsePositions())
        {
            float newDist = Vector3.Distance(transform.position, pos);
            if(minDist > newDist)
            {
                minDist = newDist;
                destination = pos;
            }
        }
        return destination;
    }
    

    
}
