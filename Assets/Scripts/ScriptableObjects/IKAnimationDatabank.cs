using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "IKAnimationDataBase", menuName = "ScriptableObjects/IKAnimationDataBase")]
public class IKAnimationDatabank : ScriptableObject
{
    public IKAnimationDataBaseObject[] IKAnimations;
    public Dictionary<IKAnimationDataBaseObject.IK_Animation_ID, IKAnimationDataBaseObject> animationDictionary = new Dictionary<IKAnimationDataBaseObject.IK_Animation_ID, IKAnimationDataBaseObject>(); 
    
    public void Init()
    {
        foreach(IKAnimationDataBaseObject anim in IKAnimations)
        {
            animationDictionary.Add(anim.iD, anim);
        }
    }

    public IKAnimationDataBaseObject GetAnimation(IKAnimationDataBaseObject.IK_Animation_ID animationID)
    {
        if(animationDictionary.ContainsKey(animationID))
        {
            return animationDictionary[animationID];
        }
        return null;
    }
}
