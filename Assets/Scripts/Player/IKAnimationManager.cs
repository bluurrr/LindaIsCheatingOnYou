using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IKAnimationManager : MonoBehaviour
{
    public GameObject ModelRoot; 
    private Dictionary<string, Transform> IKPoints =  new Dictionary<string, Transform>();

    public void Init()
    {
        IKPoint[] ikPoints = ModelRoot.GetComponentsInChildren<IKPoint>();
        foreach(IKPoint point in ikPoints)
        {
            IKPoints.Add(point.iD.ToString(), point.transform);
        }
    }

    public Transform GetIKPoint(string key)
    {
        if(IKPoints.ContainsKey(key))
        {
            return IKPoints[key];
        }
        return null;
    }

}
