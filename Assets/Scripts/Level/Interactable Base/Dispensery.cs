using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Dispensery : InteractableObject
{
    public int numberOfPresses;
    public int maxNumberOfUsers;
    public GameObject reward;  
    public UnityEvent OnCompletedInteraction;
    private int _numberOfUsers;
    private Dictionary <Player, int> _currentUsers = new Dictionary<Player,int>();

    public void Use(Player player)
    {
        if(_currentUsers.Count >= maxNumberOfUsers && !_currentUsers.ContainsKey(player)) return; 
        if(!_currentUsers.ContainsKey(player))
        {
            _currentUsers.Add(player, 0);
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
}
