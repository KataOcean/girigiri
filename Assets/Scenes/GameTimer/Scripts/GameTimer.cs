using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Girigiri
{
    public class GameTimer : MonoBehaviour
    {
        public static GameTimer Instance { get; private set; }
        public float Timer { get; private set; } = 0.0f;
        [SerializeField]
        public float TimeLimit = 180.0f;
        public float LeftTime => Mathf.Max(TimeLimit - Timer, 0.0f);
        public bool IsLeft => Timer < TimeLimit;
        private bool IsPlay { get; set; }
        public bool IsPlaying => IsLeft && IsPlay;
        private bool IsBegin { get; set; } = false;
        private List<GameObject> PlayTimeListener = new List<GameObject>();
        private List<GameObject> EndTimeListener = new List<GameObject>();
        void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else Destroy(Instance);
        }
        // Use this for initialization
        void Start()
        {
            Timer = 0.0f;
        }

        public void Play()
        {
            Timer = 0.0f;
            IsPlay = true;
            IsBegin = true;
            SceneLoader.Add(SceneName.BGM);
            PlayTimeListener.RemoveAll(x => x == null);
            foreach (var target in PlayTimeListener) ExecuteEvents.Execute<IPlayTime>(target, null, (x, data) => x.OnPlayTime());
        }

        // Update is called once per frame
        void Update()
        {
            if (IsBegin && !IsPlaying)
            {
                End();
            }
            if (IsPlaying) Timer = Mathf.Min(Timer + Time.deltaTime, TimeLimit);
        }
        void End()
        {
            EndTimeListener.RemoveAll(x => x == null);
            foreach (var target in EndTimeListener) ExecuteEvents.Execute<IEndTime>(target, null, (x, data) => x.OnEndTime());
            SceneLoader.Remove(SceneName.BGM);
            SceneLoader.Remove(gameObject.scene.name);
        }
        public void AddPlayTimeListener(GameObject listener) => PlayTimeListener.Add(listener);

        public void RemovePlayTimeListener(GameObject listener) => PlayTimeListener.Remove(listener);
        public void AddEndTimeListener(GameObject listener) => EndTimeListener.Add(listener);

        public void RemoveEndTimeListener(GameObject listener) => EndTimeListener.Remove(listener);

    }
}