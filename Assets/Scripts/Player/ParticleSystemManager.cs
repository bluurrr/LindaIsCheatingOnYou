using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSystemManager : MonoBehaviour
{
    public ParticleSystemDataBank particleSystemDataBank;
    public IKAnimationManager ikAnimationManager; 

    public void PlayParticle(ParticleSystemObject.Type type, InteractionTarget.IK_Point_Player target)
    {
        GameObject.Instantiate(particleSystemDataBank.GetParticle(type), ikAnimationManager.GetIKPoint(target).position, particleSystemDataBank.GetParticle(type).transform.rotation);
    }
}
