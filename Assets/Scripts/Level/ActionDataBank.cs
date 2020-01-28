using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Level;
using Singletons;

public class ActionDataBank : UnityInSceneSingleton<ActionDataBank>
{
    public ActionIconDataBank iconDataBank;
    private Dictionary<Action.IconTypes, Sprite> iconDictionary = new Dictionary<Action.IconTypes, Sprite>(); 
    public void Init()
    {
        foreach(var icon in iconDataBank.iconBank)
        {
            iconDictionary.Add(icon.iconType, icon.icon);
        }
    }
    public Sprite GetActionIcon(Action.IconTypes iconType)
    {
        return iconDictionary[iconType];
    }
}
