using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Inputs.Controller 
{
    public class InputEventBase : MonoBehaviour
    {
        protected void FireEvent(UnityEvent unityEvent)
        {
            if (unityEvent != null)
            {
                unityEvent.Invoke();
            }
        }
    }
}
