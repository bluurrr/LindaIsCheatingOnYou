using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ParticleSystemDataBank", menuName = "ScriptableObjects/ParticleSystemDataBank")]
public class ParticleSystemDataBank : ScriptableObject
{
    public ParticleSystemObject[] particles;
    private Dictionary<ParticleSystemObject.Type, GameObject> particlesDictionary = new Dictionary<ParticleSystemObject.Type, GameObject>();

    public void Init()
    {
        foreach(ParticleSystemObject particle in particles)
        {
            particlesDictionary.Add(particle.type, particle.prefab);
        }
    }

    public GameObject GetParticle(ParticleSystemObject.Type type)
    {
        if(particlesDictionary.ContainsKey(type))
        {
            return particlesDictionary[type];
        }
        return null; 
    }
}
