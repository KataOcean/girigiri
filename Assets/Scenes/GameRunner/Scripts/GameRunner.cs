using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Globalization;
using System.Threading;

namespace Girigiri
{
    public class GameRunner : MonoBehaviour
    {

        // Use this for initialization
        void Start()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("ja-JP");
            SceneLoader.Add(SceneName.Title);
            SceneLoader.Add(SceneName.InputManager);
            SceneLoader.Add(SceneName.Main);
            SceneLoader.Add(SceneName.SE);
            SceneLoader.Add(SceneName.HighScore);
            SceneLoader.Add(SceneName.Settings);
            SceneLoader.Remove(gameObject.scene.name);
        }
        void Update()
        {
            if (SceneLoader.IsSceneLoaded(SceneName.Title))
            {
                SceneLoader.Remove(gameObject.scene.name);
            }
        }
    }
}
