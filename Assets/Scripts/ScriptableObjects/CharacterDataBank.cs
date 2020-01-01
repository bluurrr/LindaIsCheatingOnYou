using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CharacterDataBank", menuName = "ScriptableObjects/CharacterDataBank")]
public class CharacterDataBank : ScriptableObject
{
    public enum Characters{linda, jamie};
    public List<CharacterEntry> characterEntries; 
}

