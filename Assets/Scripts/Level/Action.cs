using System.Collections;
using System.Collections.Generic;
using PlayerComponents;
using UnityEngine;
using UnityEngine.Events;

namespace Level
{
     public class Action 
    {
        public enum IconTypes{pickUp, putDown};
        public IconTypes iconType;
        public string text;
        public UnityAction action;
        public string id; 

        public Action (IconTypes iconType, string text, UnityAction action)
        {
            this.iconType = iconType;
            this.text = text;
            this.action = action;
            id = ID();
        }

        private string ID()
        {
            float id = Random.Range(float.MaxValue,float.MaxValue); 
            return iconType.ToString() + "_" + id.ToString();
        }
    }  
}

