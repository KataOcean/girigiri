using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Girigiri
{
    public class GUIGameTimer : MonoBehaviour
    {
        [SerializeField]
        private Text text;
        private GameTimer GameTimer;
        // Use this for initialization
        void Start()
        {
            GameTimer = GameTimer.Instance;
            if (GameTimer == null)
            {
                Debug.Log("GameTimer is null");
                Destroy(gameObject);
            }

        }

        // Update is called once per frame
        void Update()
        {
            if (text == null) return;
            var timer = GameTimer.LeftTime;
            text.text = string.Format("TIME: {0:D2}:{1:D2}:{2:D3}",
                (int)(timer / 60),
                (int)(timer % 60),
                (int)((timer % 1.0f) * 1000)
             );
        }
    }
}