using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyBag : PickUp
{
    public int value;
    private BankMapManager _bankMapManager;
    public ParticleSystem collectionPS; 

    private void Awake()
    {
        _bankMapManager = (BankMapManager)FindObjectOfType (typeof(BankMapManager));
    }
    private void Update()
    {
        if(IsInRangeOfGetAwayCar())
        {
            if(Input.GetButtonDown("A"))
            {
                GameManager.Instance.AddToGroupMoneyPool(value);
                Destroy();
            }
        }
        if(Input.GetButtonDown("Y"))
        {
            GameManager.Instance.AddToGroupMoneyPool(value);
            Destroy();
        }
    }


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
    private void Destroy()
    {
        Player player = GetComponentInParent<Player>();
        player.emotionManager.SetMovementStyleToCurrentMood();
        Instantiate(collectionPS, transform.position, transform.rotation); 
        player.mapManager.interactables.Remove(this);
        Destroy(gameObject);
    }
    private bool IsInRangeOfGetAwayCar()
    {
        Transform car = _bankMapManager.getAwayCar.transform;
        //print("distance: " + Vector3.Distance(transform.position, car.position));
        return Vector3.Distance(transform.position, car.position) <= 2;
    }
}




