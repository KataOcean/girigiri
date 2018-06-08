using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Girigiri
{
    public class CupTest : MonoBehaviour
    {
        private Cup Cup { get; set; }
        [SerializeField]
        private Text textSize;
        [SerializeField]
        private Text textState;
        // Use this for initialization
        void Start()
        {
            Cup = FindObjectOfType<Cup>();
            if (Cup == null)
            {
                Debug.Log("Cup is null.");
            }
        }

        // Update is called once per frame
        void Update()
        {
            SetText(textSize, string.Format("TotalSize: {0:F1}", Cup.TotalSize));
            SetText(textState, string.Format("State: {0}", Cup.State.ToString()));
        }
        void SetText(Text text, string message)
        {
            if (text == null) return;
            text.text = message;
        }
    }
}

