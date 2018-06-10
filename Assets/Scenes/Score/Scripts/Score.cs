using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Girigiri
{
    public class Score : MonoBehaviour
    {
        public static Score Instance { get; private set; }
        public float Value { get; private set; } = 0.0f;
        public const string PREFS_KEY = "HighScore";
        [SerializeField]
        private Text textAddScore;
        [SerializeField]
        private Image imageReview;
        [SerializeField]
        private Sprite goodSprite;
        [SerializeField]
        private Sprite tooShortSprite;
        [SerializeField]
        private Sprite veryGoodSprite;
        [SerializeField]
        private Sprite overSprite;
        private float DrawTimer = 0.0f;
        [SerializeField]
        private float DrawTime = 2.0f;
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
            Hide();
            Reset();
        }
        void Update()
        {
            if (DrawTimer <= 0.0f)
            {
                Hide();
            }
            else
            {
                DrawTimer = Mathf.Max(DrawTimer - Time.deltaTime, 0.0f);
            }
        }

        // Update is called once per frame
        public void AddScore(float value, int combo)
        {
            if (value > 0.0f)
            {
                SetReview((combo < 5) ? goodSprite : veryGoodSprite);
                Value += value;
            }
            if (textAddScore == null || combo < 2) return;
            textAddScore.enabled = true;
            textAddScore.text = string.Format("{0:D} combo!", (int)combo);
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

        public void Over()
        {
            SetReview(overSprite);
        }
        public void tooShort()
        {
            SetReview(tooShortSprite);
        }
        public void SetReview(Sprite sprite)
        {
            if (imageReview == null || sprite == null) return;
            DrawTimer = DrawTime;
            imageReview.enabled = true;
            imageReview.sprite = sprite;
        }

        public void Hide()
        {
            if (imageReview != null) imageReview.enabled = false;
            if (textAddScore != null) textAddScore.enabled = false;
        }
    }
}