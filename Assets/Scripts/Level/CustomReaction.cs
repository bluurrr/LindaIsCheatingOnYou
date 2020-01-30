using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CustomReaction 
{

    public IKAnimation.IK_Animation_ID emote;
    public enum Outcome{rejected_hard, rejected_soft, rejecting_hard, rejecting_soft}
    public Outcome outcome; 
    public EmotionManager.Emotions emotion; 
    public string ID()
    {
        Debug.Log("Getting id: " + emote + "_" + outcome);
        return emote + "_" + outcome;
    }
}
