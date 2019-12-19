using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Level;

public class ActionsManager : MonoBehaviour
{
    Dictionary<string,Action> floorActions = new Dictionary<string, Action>();
    public void AddFloorAction(Action action)
    {
        floorActions.Add(action.id, action);
    }

    public void RemoveFloorAction(string id)
    {
        if(floorActions.ContainsKey(id))
        {
            floorActions.Remove(id);
        }
    }

    public List<Action> GetFloorActions()
    {
        List<Action> floorActionsList = new List<Action>();
        foreach(KeyValuePair<string, Action> entry in floorActions)
        {
            floorActionsList.Add(floorActions[entry.Key]);
        }
        return floorActionsList; 
    }
}
