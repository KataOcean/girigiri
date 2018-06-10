using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Girigiri
{
    public class Tips : MonoBehaviour
    {
        [SerializeField]
        private Text text;
        [SerializeField]
        private List<string> tips;

        // Use this for initialization
        void Start()
        {
            if (text == null) return;
            var rand = Random.Range(0, tips.Count);
            text.text = tips[rand];
        }

    }

}
