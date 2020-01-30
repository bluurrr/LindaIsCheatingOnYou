using System.Collections;
using PlayerComponents;
using Level;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;


public class PickUp : InteractableObject
{
    public enum CarryAnimationSet{twoHands};
    public CarryAnimationSet animationSet;
    private string putDownID;

    public override void Investigate(Player player)
    {
        actions.AddRange(GetBaseActions());
        base.Investigate(player);
    }

    protected override void InteractionCompete()
    {
       base.InteractionCompete();  
    }

    private IEnumerator PickUpObject(Player player)
    {
        yield return UseSequence(player);
        collider.isTrigger = true;
        navMeshObject.enabled = false;
        player.animManager.ChangeToCarry(transform.parent.transform);
        player.actionsManager.AddFloorAction(CreatePutDownAction());
    }

    private IEnumerator PutDownObject(Player player, Vector3 pos)
    {
        yield return player.SetDestinationAndFace(pos);
        transform.parent.SetParent(null);
        transform.parent.transform.position = GetPutDownDestination();
        collider.isTrigger = false;
        navMeshObject.enabled = true;
        player.animManager.ChangeToWalkNeutral();
        player.actionsManager.RemoveFloorAction(putDownID);
        putDownID = "";
    }

    private List<Action> GetBaseActions()
    {
        List<Action> actions = new List<Action>();
        Action pickUp = CreatePickUpAction();
        actions.Add(pickUp);
        return actions;
    }

    private Action CreatePickUpAction()
    {
        UnityAction actionEvent = new UnityAction(ActiveUser_PickUp);
        actionEvent += InteractionCompete;
        return new Action(Action.IconTypes.pickUp, "Pick Up", actionEvent);
    }

    private Action CreatePutDownAction()
    {
        UnityAction actionEvent = new UnityAction(ActiveUser_PutDown);
        actionEvent += InteractionCompete;
        Action action = new Action(Action.IconTypes.putDown, "Put Down", actionEvent);
        putDownID = action.id;
        return action;
    }

    private void ActiveUser_PickUp()
    {
        StartCoroutine(PickUpObject(PlayersManager.Instance.GetActivePlayer()));
    }

    private void ActiveUser_PutDown()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        int layer_mask = LayerMask.GetMask(Consts.LAYER_FLOOR);
        if (Physics.Raycast(ray, out hit, float.MaxValue, layer_mask))
        {
            StartCoroutine(PutDownObject(PlayersManager.Instance.GetActivePlayer(), hit.point));
        }
    }

    private Vector3 GetPutDownDestination()
    {
        RaycastHit hit;
        if (Physics.Raycast (transform.position, Vector3.down, out hit,100))
        {
            float dist = Vector3.Distance(GetBottomOfObject(), hit.point);
            Debug.DrawLine(GetBottomOfObject(), hit.point, Color.cyan, 10);
            return transform.position + (Vector3.down * dist);
        }
        return transform.position;
    }

    private Vector3 GetBottomOfObject()
    {
        Vector3 testPoint = transform.parent.position + (Vector3.down * 100);
        return collider.ClosestPointOnBounds(testPoint); 
    }
}
