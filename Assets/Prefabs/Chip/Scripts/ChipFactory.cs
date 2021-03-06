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
        private List<GameObject> chipPrefabs;
        private GameObject nextChip
        {
            get
            {
                int i = Random.Range(0, chipPrefabs.Count);
                return chipPrefabs[i];
            }
        }
        public List<GameObject> dropListeners = new List<GameObject>();
        public List<GameObject> createListeners = new List<GameObject>();
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
            var chipObject = Instantiate(nextChip, position, Quaternion.identity);
            var chip = chipObject.GetComponent<Chip>();
            chip.ChipFactory = this;
            chips.Add(chip);
            createListeners.RemoveAll(x => x == null);
            foreach (var target in createListeners) ExecuteEvents.Execute<ICreateChip>(target, null, (x, data) => x.OnCreateChip(chip));
            return chip;
        }

        public void Remove(Chip chip)
        {
            chips.Remove(chip);
            dropListeners.RemoveAll(x => x == null);
            foreach (var target in dropListeners) ExecuteEvents.Execute<IDropChip>(target, null, (x, data) => x.OnDropChip(chip));
        }

        public void AddCreateListener(GameObject obj)
        {
            createListeners.Add(obj);
        }
        public void AddDropListener(GameObject obj)
        {
            dropListeners.Add(obj);
        }
    }

}