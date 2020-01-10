using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RootMotion.FinalIK;

public class EmotionManager : MonoBehaviour
{
    public enum Emotions{idle, happy, sad, mad, anxious, loveing};
    public Emotions currentEmotion;
    public int sadLevel, madLevel, happyLevel, anxiousLevel, loveingLevel;
    public List<EmoteLevelInformation> Sad, Mad, Happy, Anxious, Loveing;
    public Collider collider; 
    
    public void Init(PlayerLoudOut loudOut)
    {
        Sad = loudOut.Sad;
        Mad = loudOut.Mad;
        Happy = loudOut.Happy;
        Anxious = loudOut.Anxious;
        Loveing = loudOut.Loveing; 
    }

    public void Run()
    {
        OfferEmotes();
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

    private void OfferEmotes()
    {
        if(OfferEmoteTriggered())
        {
            print("i will hug you now");
        }
    }

    private bool OfferEmoteTriggered()
    {   
        RaycastHit playerCheck;
        OfferEmote_RayCast(out playerCheck);
        if(playerCheck.transform && playerCheck.transform.CompareTag(Consts.TAG_PLAYER))
        {
            print("hittiing: " + playerCheck.transform.name);
            EmotionManager otherEmoteManager = playerCheck.transform.GetComponentInParent<EmotionManager>();
            return otherEmoteManager.OfferEmote_RayCast_PlayerCheck(collider);
        }
        return false;
    }
    private bool OfferEmote_RayCast(out RaycastHit playerCheck)
    {   
        Vector3 start = transform.position + (transform.TransformDirection(Vector3.up) * .1f);
        Vector3 destination = start + (transform.TransformDirection(Vector3.forward) * .1f);
        Debug.DrawLine(start, destination, Color.red, 1);
        return Physics.Raycast(start, transform.TransformDirection(Vector3.forward) * .1f, out playerCheck);     
    }
    public bool OfferEmote_RayCast_PlayerCheck(Collider other)
    {
        RaycastHit hit;
        OfferEmote_RayCast(out hit);
        if(hit.transform && hit.transform.CompareTag(Consts.TAG_PLAYER))
        {
            print("found : " + hit.transform.parent.name + " From " + transform.name);
            EmotionManager otherEmoteManager = hit.transform.GetComponentInParent<EmotionManager>();
            return otherEmoteManager.collider == collider;
        }        
        return false;
    }



    


}
