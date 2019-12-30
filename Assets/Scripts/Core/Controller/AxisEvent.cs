using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Inputs.Controller
{
    public class AxisEvent : InputEventBase
    {
        public InputManager.Input input;
        public UnityEvent Axis_IsOne, Axis_IsZero, Axis_IsNegativeOne;
        public float inputTest;

        void Update()
        {
            ListenForAxis();
        }

        public void test()
        {
            print("i hit the button");
        }

        void ListenForAxis()
        {
            inputTest = Input.GetAxis(InputManager.Instance.GetButtonKey(input));
            if (Input.GetAxis(InputManager.Instance.GetButtonKey(input)) == 1)
            {
                FireEvent(Axis_IsOne);
            }
            else if (Input.GetAxis(InputManager.Instance.GetButtonKey(input)) == 0)
            {
                FireEvent(Axis_IsZero);
            }
            else if (Input.GetAxis(InputManager.Instance.GetButtonKey(input)) == -1)
            {
                FireEvent(Axis_IsNegativeOne);
            }
        }
    }
}
