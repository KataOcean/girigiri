using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Girigiri
{

    public class ChipFactory : MonoBehaviour
    {
        public static ChipFactory Instance;
        [SerializeField]
        private GameObject chipPrefab;
        [SerializeField]
        private List<GameObject> dropListeners = new List<GameObject>();
        [SerializeField]
        private List<GameObject> createListeners = new List<GameObject>();
        private List<Chip> chips = new List<Chip>();
        public IReadOnlyCollection<Chip> Chips => chips;
        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else Destroy(gameObject);
        }

        public Chip Create(Vector2 position)
        {
            var chipObject = Instantiate(chipPrefab, position, Quaternion.identity);
            var chip = chipObject.GetComponent<Chip>();
            chip.ChipFactory = this;
            chips.Add(chip);
            foreach (var target in createListeners) ExecuteEvents.Execute<ICreateChip>(target, null, (x, data) => x.OnCreate(chip));
            return chip;
        }

        public void Remove(Chip chip)
        {
            chips.Remove(chip);
            foreach (var target in dropListeners) ExecuteEvents.Execute<IDropChip>(target, null, (x, data) => x.OnDrop(chip));
        }
    }

}