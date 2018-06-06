using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Girigiri
{
    public class InputManagerTest : MonoBehaviour
    {
        InputManager InputManager { get; set; }
        public Text TextPosition;
        public Text TextEnter;
        // Use this for initialization
        void Start()
        {
            InputManager = InputManager.Instance;
            if (InputManager == null)
            {
                Debug.Log("InputManager is null.");
                Destroy(InputManager);
            }
        }

        // Update is called once per frame
        void Update()
        {
            var state = InputManager.State;
            SetText(TextPosition, string.Format("X:{0:F1} Y:{1:F1}", state.Position.x, state.Position.y));
            SetText(TextEnter, string.Format("Enter: {0}", state.Enter));
        }

        void SetText(Text text, string mes)
        {
            if (text != null) text.text = mes;
        }
    }

}