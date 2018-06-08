using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Girigiri
{
    public class Result : MonoBehaviour
    {
        public void Replay()
        {
            SceneLoader.Add(SceneName.GameTimer);
            Score.Instance?.Reset();
            SceneLoader.Remove(gameObject.scene.name);
        }
    }
}