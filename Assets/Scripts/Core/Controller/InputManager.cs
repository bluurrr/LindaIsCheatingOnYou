using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Singletons;

namespace Inputs.Controller
{
    public class InputManager : UnityInSceneSingleton<InputManager>
    {
        public enum Input { A, X, Y, B, RTrigger, LTrigger };

        public const string A_InputKey = "A";
        public const string X_InputKey = "X";
        public const string RTrigger_InputKey = "RTrigger";
        public const string LTrigger_InputKey = "LTrigger";



        private Dictionary<Input, string> InputKeys = new Dictionary<Input, string>();

        void Awake()
        {
            InputKeys.Add(Input.A, A_InputKey);
            InputKeys.Add(Input.X, X_InputKey);
            InputKeys.Add(Input.LTrigger, LTrigger_InputKey);
            InputKeys.Add(Input.RTrigger, RTrigger_InputKey);
        }

        public string GetButtonKey(Input input)
        {
            return InputKeys[input];
        }


    }
}
