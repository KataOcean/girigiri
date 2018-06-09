using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Girigiri
{
    public class CupTest : MonoBehaviour, ICreateCup
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
            CupFactory.Instance.AddCreateListener(gameObject);
        }

        // Update is called once per frame
        void Update()
        {
            if (Cup == null || Cup.TotalSize < 5.0f) return;
            SetText(textSize, string.Format("TotalSize: {0:F1}", Cup.TotalSize));
            SetText(textState, string.Format("State: {0}", Cup.State.ToString()));
        }
        void SetText(Text text, string message)
        {
            if (text == null) return;
            text.text = message;
        }

        public void OnCreateCup(Cup cup)
        {
            Cup = cup;
        }
    }
}

