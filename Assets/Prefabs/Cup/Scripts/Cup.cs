﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace Girigiri
{
    public class Cup : MonoBehaviour
    {
        private List<Chip> Chips = new List<Chip>();
        [SerializeField]
        private float StandardScore = 500.0f;
        public float TotalSize
        {
            get
            {
                if (State == CupState.Broken) return .0f;
                return CountSize();
            }
        }
        [SerializeField]
        private Transform GoalHeight;
        public float Score
        {
            get
            {
                if (!IsGoal) return 0.0f;
                return (TotalSize / StandardSize) * StandardScore;
            }
        }
        public bool IsGoal => CheckTopHeight() >= GoalHeight.position.y;
        [SerializeField]
        private float StandardSize = 30.0f;
        private List<CupEdge> CupEdges { get; set; } = new List<CupEdge>();
        public CupState State { get; set; } = CupState.Wait;
        public CupFactory CupFactory;
        [SerializeField]
        private AudioClip brokenClip;
        [SerializeField]
        private LimitLine limitLine;
        // Use this for initialization
        void Start()
        {
            CupEdges.AddRange(GetComponentsInChildren<CupEdge>());
            State = CupState.Ready;
        }

        // Update is called once per frame
        void Update()
        {
            Chips.RemoveAll(x => x == null);
            if (limitLine != null) limitLine.ChangeLine(IsGoal);
            if (State == CupState.Pouring)
            {
                if (Chips.Count > 0 && Chips.Find(x => !x.IsStop) == null)
                {
                    if (IsGoal) Complete();
                    else
                    {
                        Girigiri.Score.Instance?.tooShort();
                        Broken();
                    }
                }
            }
        }

        void Complete()
        {
            State = CupState.Complete;
            CupFactory?.Complete(this);
            if (limitLine != null) Destroy(limitLine.gameObject);
            foreach (var chip in Chips)
            {
                if (chip != null) chip.Fix();
            }
        }

        float CheckTopHeight()
        {
            Chips.RemoveAll(x => x == null);
            var height = Chips.Where(x => x.IsStop)?.Select(x => x.transform.position.y);
            if (height.Count() == 0) return -9999.0f;
            return height.Max();
        }
        public void HideLimitLine()
        {
            if (limitLine == null) return;
            limitLine.Hide();
        }

        float CountSize()
        {
            Chips.RemoveAll(x => x == null);
            return Chips.Where(x => x.IsStop).Select(x => x.Size).Sum();
        }
        void OnDestroy()
        {
            Chips.RemoveAll(x => x == null);
            foreach (var chip in Chips) Destroy(chip.gameObject);
        }
        public void AddChip(Chip chip)
        {
            if ((State != CupState.Ready && State != CupState.Pouring) || chip == null) return;
            Chips.Add(chip);
            chip.transform.SetParent(transform);
            if (State == CupState.Ready) State = CupState.Pouring;
        }

        public void Broken()
        {
            if (State == CupState.Pouring)
            {
                State = CupState.Broken;
                SE.Instance?.Play(brokenClip);
                CupFactory?.Broken(this);
                if (limitLine != null) Destroy(limitLine.gameObject);
            }

            foreach (var edge in CupEdges) if (edge != null) edge.Broken();
            foreach (var chip in Chips) if (chip != null) chip.Broken();
        }
    }
}
