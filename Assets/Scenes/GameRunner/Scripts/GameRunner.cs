using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Girigiri
{
    public class GameRunner : MonoBehaviour
    {

        // Use this for initialization
        void Start()
        {
            SceneLoader.Add(SceneName.Title);
            SceneLoader.Add(SceneName.InputManager);
            SceneLoader.Add(SceneName.Main);
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
