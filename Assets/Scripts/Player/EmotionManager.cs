using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RootMotion.FinalIK;
using PlayerComponents;
using System;

public class EmotionManager : MonoBehaviour
{
    public enum Emotions{idle, happy, sad, mad, anxious, loveing};
    public Emotions currentEmotion;
    public List<EmoteLevelInformation> Sad, Mad, Happy, Anxious, Loveing;
    public Player player;
    public bool monitorMe;
    public AnimManager animManager;
    private Dictionary<string, Emotions> reactions = new Dictionary<string, Emotions>();
    private Dictionary<Emotions, int> experience = new Dictionary<Emotions, int>();
    private const int LEVEL_INCRIMENT = 100;


    public void Init(PlayerLoudOut loudOut)
    {
        Sad = loudOut.Sad;
        Mad = loudOut.Mad;
        Happy = loudOut.Happy;
        Anxious = loudOut.Anxious;
        Loveing = loudOut.Loveing; 

        foreach(var reaction in loudOut.reactions)
        {
            reactions.Add(reaction.ID(), reaction.emotion);
        }

        var emotions = Enum.GetValues(typeof(Emotions));
        foreach(Emotions emot in emotions)
        {
            experience.Add(emot, 0);
        }
    }
    public List<IKAnimation.IK_Animation_ID> GetCurrentMoodEmotes()
    {
        switch(currentEmotion)
        {
            case Emotions.happy:
                return GetMoodEmotes(GetLevel(currentEmotion), Happy);
            case Emotions.sad:
                return GetMoodEmotes(GetLevel(currentEmotion), Sad);
            case Emotions.mad:
                return GetMoodEmotes(GetLevel(currentEmotion), Mad);
            case Emotions.anxious:
                return GetMoodEmotes(GetLevel(currentEmotion), Anxious);
            case Emotions.loveing:
                return GetMoodEmotes(GetLevel(currentEmotion), Loveing);
        }
        return null;
    }
    public void PlayCustomReaction(string key)
    {
        if(reactions.ContainsKey(key))
        {
            Emotions emotion = reactions[key];
            AddExperience(emotion, 101); 
            PlayReaction(emotion); 
        }
    }

    private void PlayReaction(Emotions emotion)
    {
        SetMotionStyleID(emotion);
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
    private int ExperienceRequired(int level)
    {
        return LEVEL_INCRIMENT * level;
    }
    private void AddExperience(Emotions emotion, int xp)
    {
        int newXP = experience[emotion] + xp;
        experience[emotion] = newXP;
    }
    private int GetLevel(Emotions emotion)
    {
        return Mathf.RoundToInt(experience[emotion] / LEVEL_INCRIMENT);
    }
    private void SetMotionStyleID(Emotions emotion)
    {
        switch(emotion)
        {
            case Emotions.happy:
                break;
            case Emotions.sad:
                animManager.ChangeToWalkSad();
                break;
            case Emotions.mad:
                animManager.ChangeToWalkAngry();
                break;
            case Emotions.anxious:
                break;
            case Emotions.loveing:
                break;
        }
    }

}
