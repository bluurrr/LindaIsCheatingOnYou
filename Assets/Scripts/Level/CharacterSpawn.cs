using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSpawn : MonoBehaviour
{
    public bool neutralSpawn;
    public CharacterDataBank.Characters character;

    public Vector3 SpawnPoint()
    {
        return transform.position;
    }
}
