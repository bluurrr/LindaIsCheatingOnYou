using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "IKAnimationDataBase", menuName = "ScriptableObjects/IKAnimationDataBase")]
public class IKAnimationDatabank : ScriptableObject
{
    public IKAnimation[] IKAnimations;
    public Dictionary<IKAnimation.IK_Animation_ID, IKAnimation> animationDictionary = new Dictionary<IKAnimation.IK_Animation_ID, IKAnimation>(); 
    
    public void Init()
    {
        foreach(IKAnimation anim in IKAnimations)
        {
            animationDictionary.Add(anim.iD, anim);
        }
    }

    public IKAnimation GetAnimation(IKAnimation.IK_Animation_ID animationID)
    {
        if(animationDictionary.ContainsKey(animationID))
        {
            return animationDictionary[animationID];
        }
        return null;
    }
}
