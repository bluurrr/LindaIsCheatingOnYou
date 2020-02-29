using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Dispensery : InteractableObject
{
    public int numberOfPresses;
    public int maxNumberOfUsers;
    public GameObject reward;  
    private Dictionary <Player, int> _currentUsers = new Dictionary<Player,int>();

    public override void Use(Player player)
    {
        if(!CanInteract(player)) return; 
        if(_currentUsers.Count >= maxNumberOfUsers && !_currentUsers.ContainsKey(player)) return;

        if(!_currentUsers.ContainsKey(player))
        {
            _currentUsers.Add(player, 0);
            player.PauseInput_All();
            player.animManager.SetMovementToIdle();
            StartCoroutine(player.Face(transform.position, .25f));
        }
        Press(player);
    }
    private void Press(Player player)
    {
        _currentUsers[player]++;
        if(_currentUsers[player] < numberOfPresses) return; 
        
    }
    private void ShowUI(Player player)
    {

    }

    public override void Cancel(Player player)
    {
        if(_currentUsers.ContainsKey(player))
        {
            _currentUsers.Remove(player);
            player.EnableInput_All();
        }
    }
}
