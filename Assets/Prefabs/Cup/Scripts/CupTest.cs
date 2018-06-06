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
            if (textSize == null) return;
            textSize.text = string.Format("TotalSize: {0:F1}", Cup.TotalSize);
        }
    }
}

