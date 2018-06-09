using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Girigiri
{
    public class Bartender : MonoBehaviour, ICreateCup, ICompleteCup, IBrokenCup, ICreateChip, IDropChip, IPlayTime, IEndTime
    {
        [SerializeField]
        private Pot pot;
        private ChipFactory ChipFactory;
        private CupFactory CupFactory;
        [SerializeField]
        private Cup cup;
        public int Combo { get; private set; } = 0;
        private InputManager InputManager;
        private GameTimer GameTimer;
        private bool CanControl { get; set; } = false;
        [SerializeField]
        private PlayArea playArea;
        [SerializeField]
        private AudioClip addScoreClip;
        [SerializeField]
        private AudioClip openClip;
        [SerializeField]
        private AudioClip closeClip;
        private int openFlame = 0;

        // Use this for initialization
        void Start()
        {
            ChipFactory = ChipFactory.Instance;
            CupFactory = CupFactory.Instance;
            InputManager = InputManager.Instance;
        }

        // Update is called once per frame
        void Update()
        {
            if (InputManager == null || pot == null) return;
            if (CanControl)
            {
                if (Input.GetKeyDown(KeyCode.R))
                {
                    SceneLoader.Replace(SceneName.GameRunner);
                    return;
                }
                var state = InputManager.State;
                var pos = new Vector2(
                    Mathf.Clamp(state.Position.x, playArea.XMin, playArea.XMax),
                    Mathf.Clamp(state.Position.y, playArea.YMin, playArea.YMax)
                );

                pot.Move(pos);
                if (openFlame == 1)
                {
                    SE.Instance?.Play(openClip);
                }
                if (state.Enter)
                {
                    pot.Pour();
                    openFlame++;
                }
                else
                {
                    if (openFlame > 0) SE.Instance?.Play(closeClip);
                    openFlame = 0;
                }
            }
            if (GameTimer == null)
            {
                SetGameTimer(GameTimer.Instance);
            }

        }
        void SetGameTimer(GameTimer timer)
        {
            if (timer == null) return;
            GameTimer = timer;
            GameTimer.AddPlayTimeListener(gameObject);
            GameTimer.AddEndTimeListener(gameObject);
            GameTimer.Play();
        }
        public void OnCreateChip(Chip chip)
        {
            cup?.AddChip(chip);
        }
        public void OnDropChip(Chip chip)
        {
            cup?.Broken();
        }
        public void OnCreateCup(Cup _cup)
        {
            cup = _cup;
        }

        public void OnCompleteCup(Cup _cup)
        {
            var score = Score.Instance;
            score?.AddScore(_cup.Score * ((Combo > 0) ? Combo : 1));
            SE.Instance?.Play(addScoreClip);
            if (_cup.IsGoal) Combo++;
            else Combo = 0;
            Destroy(_cup.gameObject);
            CupFactory.Create();
        }
        public void OnBrokenCup(Cup _cup)
        {
            Combo = 0;
            CupFactory.Create();
        }
        public void OnPlayTime()
        {
            CanControl = true;
            CupFactory.Create();
            Combo = 0;
        }
        public void OnEndTime()
        {
            CanControl = false;
            CupFactory.RemoveBrokenListener(gameObject);
            cup.Broken();
            CupFactory.AddBrokenListener(gameObject);
            SceneLoader.Add(SceneName.Result);
        }
    }
}