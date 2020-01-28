using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerLoudOut 
{
    public string name;
    public CharacterDataBank.Characters character;
    public List<EmoteLevelInformation> Sad, Mad, Happy, Anxious, Loveing;
    public List<CustomReaction> reactions;
}
