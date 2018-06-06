using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Girigiri
{
    public class MouseInput : MonoBehaviour
    {
        [SerializeField]
        InputManager inputManager;

        enum MouseButtons
        {
            LEFT_BUTTON = 0,
        }

        // Use this for initialization
        void Start()
        {
            if (inputManager == null)
            {
                Debug.Log("InputManager is null.");
                Destroy(this);
            }
        }

        // Update is called once per frame
        void Update()
        {
            InputState state = inputManager.State;
            Camera main = Camera.main;
            var position = main.ScreenToWorldPoint(Input.mousePosition);
            var leftDown = Input.GetMouseButton((int)MouseButtons.LEFT_BUTTON);

            state.Position = new Vector2(position.x, position.y);
            state.Enter = leftDown;

            inputManager.SetState(state);
        }
    }
}
