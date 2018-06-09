using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Girigiri
{
    public class Title : MonoBehaviour
    {
        public void StartGame()
        {
            SceneLoader.Add(SceneName.GameTimer);
            SceneLoader.Add(SceneName.Score);
            SceneLoader.Remove(SceneName.Settings);
            SceneLoader.Remove(SceneName.HighScore);
            SceneLoader.Remove(gameObject.scene.name);
        }
    }
}
