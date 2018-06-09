using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Girigiri
{
    public class Score : MonoBehaviour
    {
        public static Score Instance { get; private set; }
        public float Value { get; private set; } = 0.0f;
        public const string PREFS_KEY = "HighScore";
        public static float HighScore
        {
            get
            {
                return PlayerPrefs.GetFloat(PREFS_KEY, 10000.0f);
            }
        }
        void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else Destroy(gameObject);
        }
        // Use this for initialization
        void Start()
        {
            Reset();
        }

        // Update is called once per frame
        public void AddScore(float value)
        {
            Value += value;
        }
        public void Reset()
        {
            Value = 0.0f;
        }
        public void SaveHighScore()
        {
            if (HighScore < Value)
            {
                PlayerPrefs.SetFloat(PREFS_KEY, Value);
                PlayerPrefs.Save();
            }
        }
    }
}