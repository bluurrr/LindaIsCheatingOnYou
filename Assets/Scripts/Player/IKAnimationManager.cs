using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RootMotion.FinalIK;

public class IKAnimationManager : MonoBehaviour
{
    public GameObject ModelRoot; 
    public FullBodyBipedIK fullBodyBipedIK;
    public InteractionSystem interactionSystem;
    public Transform ikSpawn, headspawn;
    //private Dictionary<string, Transform> IKPoints =  new Dictionary<string, Transform>();
    private Pose currentPose;
    public void Init()
    {
        // IKTarget[] ikPoints = ModelRoot.GetComponentsInChildren<IKTarget>();
        // foreach(IKTarget point in ikPoints)
        // {
        //     IKPoints.Add(point.iD.ToString(), point.transform);
        // }
    }

    public void Run()
    {
        if(currentPose == null) return;
        currentPose.RunAnim(fullBodyBipedIK);
        StopEmote();
    }

    public Transform GetIKPoint(string key)
    {
        // if(IKPoints.ContainsKey(key))
        // {
        //     return IKPoints[key];
        // }
        return null;
    }

    public void PlayEmote(IKAnimation ikObj)
    {
        Pose pose = Instantiate(ikObj.prefab, ikSpawn).GetComponent<Pose>();
        pose.Init();
        currentPose = pose; 
    }
    private void StopEmote()
    {
        if(Input.GetButtonDown("B"))
        {
            currentPose.StopAnim(fullBodyBipedIK);
            currentPose = null;
            foreach(Transform emote in ikSpawn)
            {
                Destroy(emote.gameObject);
            }
        }
    }




}
