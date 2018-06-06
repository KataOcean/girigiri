using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace Girigiri
{
    public class Cup : MonoBehaviour, ICreateChip, IDropChip
    {
        private List<Chip> Chips = new List<Chip>();
        public float TotalSize
        {
            get
            {
                return CountSize();
            }
        }

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        float CountSize()
        {
            Chips.RemoveAll(x => x == null);
            return Chips.Where(x => x.IsStop).Select(x => x.Size).Sum();
        }
        public void OnCreate(Chip chip)
        {
            if (chip == null) return;
            Chips.Add(chip);
        }

        public void OnDrop(Chip chip)
        {
            Debug.Log("drop!");
        }
    }
}
