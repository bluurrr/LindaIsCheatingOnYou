using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Level;

[CreateAssetMenu(fileName = "ActionIconDataBase", menuName = "ScriptableObjects/ActionIconDataBase")]
public class ActionIconDataBank : ScriptableObject
{
    public ActionIcon[] iconBank;
}
