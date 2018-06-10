using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Girigiri
{
    public class HighScore : MonoBehaviour
    {
        [SerializeField]
        private Text highScoreText;
        [SerializeField]
        private AudioClip deleteClip;
        // Use this for initialization
        void Start()
        {
            if (highScoreText != null)
            {
                if (Score.HighScore > 0.0f)
                {
                    highScoreText.text = string.Format("最高売上 {0:C}", (int)Score.HighScore);
                }
                else
                {
                    highScoreText.enabled = false;
                }
            }
        }
        public void Reset()
        {
            SE.Instance?.Play(deleteClip);
            PlayerPrefs.DeleteKey(Score.PREFS_KEY);
            Start();
        }
    }
}
