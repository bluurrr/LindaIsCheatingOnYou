﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmotionManager : MonoBehaviour
{
    public enum Emotions{idle, happy};
    public Emotions currentEmotion; 
    public List<EmoteLevelInformation> Sad, Mad, Happy, Anxious, Loveing;

}
