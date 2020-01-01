using System.Collections;
using System.Collections.Generic;
using LivelyChatBubbles;
using UnityEngine;

public class EmoteButtonSpawn : MonoBehaviour
{
    public ExtenderBorderEnum extenderDock;
    public float position; 
    public int spawnOrder;
    public void SetUp(ChatBubble chatBubble)
    {
        chatBubble.ExtenderDock = extenderDock;
        chatBubble.ExtenderPosition = Mathf.Clamp(position, 0, 1); 
    }

}
