﻿using System.Collections;
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

        // Use this for initialization
        void Start()
        {
            ChipFactory = ChipFactory.Instance;
            CupFactory = CupFactory.Instance;
            InputManager = InputManager.Instance;
            GameTimer = GameTimer.Instance;
        }

        // Update is called once per frame
        void Update()
        {
            if (InputManager == null || pot == null) return;
            if (CanControl)
            {
                var state = InputManager.State;
                var pos = new Vector2(
                    Mathf.Clamp(state.Position.x, playArea.XMin, playArea.XMax),
                    Mathf.Clamp(state.Position.y, playArea.YMin, playArea.YMax)
                );

                pot.Move(pos);
                if (state.Enter)
                {
                    pot.Pour();
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
            if (_cup.IsOverStandard) Combo++;
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
            CupFactory.AddBrokenListener(gameObject);
            CupFactory.Create();
        }
        public void OnEndTime()
        {
            CanControl = false;
            CupFactory.RemoveBrokenListener(gameObject);
            cup.Broken();
            SceneLoader.Add("Result");
        }
    }
}