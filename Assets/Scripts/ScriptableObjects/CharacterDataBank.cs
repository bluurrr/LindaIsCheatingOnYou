using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CharacterDataBank", menuName = "ScriptableObjects/CharacterDataBank")]
public class CharacterDataBank : ScriptableObject
{
    public enum Characters{linda, jamie};
    public List<CharacterEntry> characterEntries; 
    private Dictionary<CharacterDataBank.Characters,CharacterEntry> characterDictionary = new Dictionary<Characters, CharacterEntry>();

    public void Init()
    {
        foreach(CharacterEntry characterEntry in characterEntries)
        {
            characterDictionary.Add(characterEntry.character, characterEntry);
        }
    }

    public GameObject GetCharacter(CharacterDataBank.Characters character)
    {
        if(characterDictionary.ContainsKey(character))
        {
            return characterDictionary[character].prefab;
        }
        return null; 
    }
}

