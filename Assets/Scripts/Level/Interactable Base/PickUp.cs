using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : InteractableObject
{
    public enum AnimTypes {twoHanded_front, twoHanded_weapon};
    public AnimTypes animType; 
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
        CarryAnim(animType, player);
        player.interactableObjectManager.SetObjectInUse(this); 
    }

    private void CarryAnim(AnimTypes type, Player player)
    {
        switch (type)
        {
            case AnimTypes.twoHanded_front: 
                player.animManager.ChangeToCarry_Front(transform);
            break;
            case AnimTypes.twoHanded_weapon: 
                player.animManager.ChangeToCarry_TwoHanded_Weapon(transform);
            break;
        }
    }
    
}
