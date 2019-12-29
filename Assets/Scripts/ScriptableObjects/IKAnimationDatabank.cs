using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "IKAnimationDataBase", menuName = "ScriptableObjects/IKAnimationDataBase")]
public class IKAnimationDatabank : ScriptableObject
{
    public IKAnimationDataBaseObject[] IKAnimations; 
}
