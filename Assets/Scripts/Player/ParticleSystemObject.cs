using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ParticleSystemObject
{
    public enum Type {poof};
    public Type type; 
    public GameObject prefab; 
}
