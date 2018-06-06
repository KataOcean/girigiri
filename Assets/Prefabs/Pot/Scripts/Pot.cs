using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Girigiri
{
    public class Pot : MonoBehaviour
    {
        private InputManager InputManager;

        [SerializeField]
        private PourPosition pourPosition;
        private bool IsPause { get; set; }
        // Use this for initialization
        void Start()
        {
            InputManager = InputManager.Instance;
        }

        // Update is called once per frame
        void Update()
        {
            if (InputManager == null) return;
            var state = InputManager.State;
            transform.position = new Vector3(state.Position.x, state.Position.y, transform.position.z);
            if (state.Enter)
            {
                if (!IsPause) Pour();
            }
            else IsPause = false;

        }

        void Pour()
        {
            if (pourPosition == null) return;
            if (!pourPosition.canPour) return;
            ChipFactory.Instance?.Create(pourPosition.Position);
        }

        public void Pause()
        {
            IsPause = true;
        }
    }
}