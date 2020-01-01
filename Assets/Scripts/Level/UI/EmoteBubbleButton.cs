using System.Collections;
using System.Collections.Generic;
using LivelyChatBubbles;
using UnityEngine;
using UnityEngine.UI;


public class EmoteBubbleButton : MonoBehaviour
{
    public Image icon, bubble, extender;
    public Color normal, hover, selected;
    public ChatBubble chatBubble;

    public void SetUp(Sprite icon)
    {
        this.icon.sprite = icon;
        Normal();
    }

    public void Selected()
    {
        bubble.color = selected;
        extender.color = selected;
    }

    public void Hover()
    {
        bubble.color = hover;
        extender.color = hover;
    }

    public void Normal()
    {
        bubble.color = normal;
        extender.color = normal;
    }
}
