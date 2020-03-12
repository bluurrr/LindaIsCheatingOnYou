using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyBag : PickUp
{
    public override void Use(Player player)
    {
        if(!CanInteract(player)) return; 
        base.Use(player); 
        player.interactableObjectManager.SetCanInteract(false);
    }
    public override void Cancel(Player player)
    {
        base.Cancel(player); 
    }
}
