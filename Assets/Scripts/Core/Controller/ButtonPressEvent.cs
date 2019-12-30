using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Inputs.Controller
{
    public class ButtonPressEvent : InputEventBase
    {
        public InputManager.Input input;
        public UnityEvent buttonDown, button, buttonUp;

        void Update()
        {
            ListenForButton();
        }

        public void test()
        {
            print("i hit the button");
        }

        void ListenForButton()
        {
            if (Input.GetButtonDown(InputManager.Instance.GetButtonKey(input)))
            {
                FireEvent(buttonDown);
            }
            else if (Input.GetButton(InputManager.Instance.GetButtonKey(input)))
            {
                FireEvent(button);
            }
            else if (Input.GetButtonUp(InputManager.Instance.GetButtonKey(input)))
            {
                FireEvent(buttonUp);
            }
        }
    }
}

