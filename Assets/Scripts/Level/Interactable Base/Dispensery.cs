using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Dispensery : InteractableObject
{
    public int numberOfPresses;
    public int maxNumberOfUsers;
    private Dictionary <Player, int> _currentUsers = new Dictionary<Player,int>();

    public override void Use(Player player)
    {
        if(!CanInteract(player)) return; 
        if(IsFull(player)) return;

        if(!_currentUsers.ContainsKey(player))
        {
            _currentUsers.Add(player, 0);
            player.PauseInput_All();
            player.animManager.SetMovementToIdle();
            StartCoroutine(player.Face(transform.position, .25f));
        }
        Press(player);
    }
    public override void Cancel(Player player)
    {
            RemoveUser(player);
    }


    protected void Press(Player player)
    {
        _currentUsers[player]++;   
    }
    protected void RemoveUser(Player player)
    {
        if(_currentUsers.ContainsKey(player))
        {
            _currentUsers.Remove(player);
            player.EnableInput_All();
        }
    }
    protected bool ButtonPressGoalMeet(Player player)
    {
        if(!_currentUsers.ContainsKey(player)) return false;
        return _currentUsers[player] >= numberOfPresses;
    }
    protected bool IsOnEntry(Player player)
    {
        return !IsFull(player) && !_currentUsers.ContainsKey(player);
    }

    private bool IsFull(Player player)
    {
        return _currentUsers.Count >= maxNumberOfUsers && !_currentUsers.ContainsKey(player);
    }
    private void ShowUI(Player player)
    {

    }


}
