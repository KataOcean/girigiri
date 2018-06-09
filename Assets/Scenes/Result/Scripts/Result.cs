using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using naichilab;

namespace Girigiri
{
    public class Result : MonoBehaviour
    {
        private void Start()
        {
            Score.Instance?.SaveHighScore();
            SceneLoader.Add(SceneName.HighScore);

        }
        public void Replay()
        {
            SceneLoader.Add(SceneName.GameTimer);
            Score.Instance?.Reset();
            SceneLoader.Remove(SceneName.HighScore);
            SceneLoader.Remove(gameObject.scene.name);
        }

        public void Tweet()
        {
            var score = Score.Instance;
            if (score == null) return;

            string text = string.Format("あなたの売上は {0:C} でした。", (int)score.Value);
            if (Application.platform == RuntimePlatform.WebGLPlayer)
            {
                naichilab.UnityRoomTweet.Tweet("sosogugame", text, "注ぐゲーム", "unityroom", "unity1week");
            }
            else
            {
                Application.OpenURL("http://twitter.com/intent/tweet?text=" + WWW.EscapeURL(text + " #注ぐゲーム"));
            }

        }
    }
}