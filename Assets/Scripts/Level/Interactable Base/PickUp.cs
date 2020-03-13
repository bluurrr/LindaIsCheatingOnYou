using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : InteractableObject
{
    public Rigidbody rigidbody; 
    public override void Use(Player player)
    {
        if(!CanInteract(player)) return; 
        Carry(player);

    }
    public override void Cancel(Player player)
    {
        transform.SetParent(null);
        collider.isTrigger = false;
        rigidbody.useGravity = true; 
        rigidbody.isKinematic = false;
        rigidbody.AddForce(transform.forward * 20);
        rigidbody.AddForce(transform.up * 30);
    }

    private void Carry(Player player)
    {
        rigidbody.useGravity = false; 
        rigidbody.isKinematic = true;
        collider.isTrigger = true;
        transform.rotation =  player.iKAnimationManager.GetIKPoint(InteractionTarget.IK_Point_Player.Object_Front).transform.rotation;
        player.animManager.ChangeToCarry(transform);
        player.interactableObjectManager.SetObjectInUse(this); 
    }
    
}
