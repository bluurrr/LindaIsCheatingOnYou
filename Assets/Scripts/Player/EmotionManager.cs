using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmotionManager : MonoBehaviour
{
    public enum Emotions{idle, happy, sad, mad, anxious, loveing};
    public Emotions currentEmotion;
    public int sadLevel, madLevel, happyLevel, anxiousLevel, loveingLevel;
    public List<EmoteLevelInformation> Sad, Mad, Happy, Anxious, Loveing;
    public void Init(PlayerLoudOut loudOut)
    {
        Sad = loudOut.Sad;
        Mad = loudOut.Mad;
        Happy = loudOut.Happy;
        Anxious = loudOut.Anxious;
        Loveing = loudOut.Loveing; 
    }

    public List<IKAnimation.IK_Animation_ID> GetCurrentMoodEmotes()
    {
        switch(currentEmotion)
        {
            case Emotions.happy:
                return GetMoodEmotes(happyLevel, Happy);
            case Emotions.sad:
                return GetMoodEmotes(sadLevel, Sad);
            case Emotions.mad:
                return GetMoodEmotes(madLevel, Mad);
            case Emotions.anxious:
                return GetMoodEmotes(anxiousLevel, Anxious);
            case Emotions.loveing:
                return GetMoodEmotes(loveingLevel, Loveing);
        }
        return null;
    }

    private List<IKAnimation.IK_Animation_ID> GetMoodEmotes(int level, List<EmoteLevelInformation> emotion)
    {
        List<IKAnimation.IK_Animation_ID> anims = new List<IKAnimation.IK_Animation_ID>();
        foreach(EmoteLevelInformation levelInformation in emotion)
        {
            if(levelInformation.level == level)
            {
                anims.Add(levelInformation.iK_Animation);
            }
        }
        return anims;
    }


    


}
