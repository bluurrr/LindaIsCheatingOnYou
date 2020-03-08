using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyTable : Dispensery
{
    public GameObject bag;

    public override void Use(Player player)
    {
        if(IsOnEntry(player))
        {
            OnEnter(player);
        }
        base.Use(player);
        if(ButtonPressGoalMeet(player))
        {
            OnComplete(player);
        }
        else
        {
            OnButtonPress(player);
        }
    }
    public override void Cancel(Player player)
    {
        base.Cancel(player);
        foreach (Transform item in player.iKAnimationManager.GetIKPoint(InteractionTarget.IK_Point_Player.Object_UnderArm_Left).transform)
        {
            Destroy(item.gameObject);
        }
        player.emotionManager.SetMovementStyleToCurrentMood();
    }
    public void OnEnter(Player player)
    {
        GameObject moneyBag = Instantiate(bag, player.transform.position,player.iKAnimationManager.GetIKPoint(InteractionTarget.IK_Point_Player.Object_UnderArm_Left).transform.rotation);
        player.animManager.ChangeToCarryUnderArm(moneyBag.transform);
    }
    public void OnButtonPress(Player player)
    {
        player.animManager.Grab_Underarm();
    }
    public void OnComplete(Player player)
    {
       GameObject moneyBag = player.iKAnimationManager.GetIKPoint(InteractionTarget.IK_Point_Player.Object_UnderArm_Left).transform.GetChild(0).gameObject;
       moneyBag.transform.rotation =  player.iKAnimationManager.GetIKPoint(InteractionTarget.IK_Point_Player.Object_Front).transform.rotation;
        player.animManager.ChangeToCarry(moneyBag.transform);
        RemoveUser(player);
        player.interactableObjectManager.SetCanInteract(false);

    }
}
