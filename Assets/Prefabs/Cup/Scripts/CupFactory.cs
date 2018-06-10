using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System.Linq;

namespace Girigiri
{

    public class CupFactory : MonoBehaviour
    {
        public static CupFactory Instance;
        [SerializeField]
        private Transform CreatePosition;
        [SerializeField]
        private List<GameObject> cupPrefabs;
        private GameObject NextCup
        {
            get
            {
                if (CupNum < cupPrefabs.Count) return cupPrefabs[CupNum];
                int rand = UnityEngine.Random.Range(0, cupPrefabs.Count);
                return cupPrefabs[rand];
            }
        }
        [SerializeField]
        private List<GameObject> completeListeners = new List<GameObject>();
        [SerializeField]
        private List<GameObject> brokenListeners = new List<GameObject>();
        [SerializeField]
        private List<GameObject> createListeners = new List<GameObject>();
        private int CupNum = 0;
        private const int SHOW_LIMIT_LINE_NUM = 5;
        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else Destroy(gameObject);
        }
        public Cup Create()
        {
            var cupObject = Instantiate(NextCup, CreatePosition.position, Quaternion.identity);
            var cup = cupObject.GetComponent<Cup>();
            cup.CupFactory = this;
            foreach (var target in createListeners) ExecuteEvents.Execute<ICreateCup>(target, null, (x, data) => x.OnCreateCup(cup));
            CupNum++;
            if (CupNum > SHOW_LIMIT_LINE_NUM) cup.HideLimitLine();
            return cup;
        }
        public void ResetCupNum()
        {
            CupNum = 0;
        }

        public void Complete(Cup cup)
        {
            foreach (var target in completeListeners) ExecuteEvents.Execute<ICompleteCup>(target, null, (x, data) => x.OnCompleteCup(cup));
        }
        public void Broken(Cup cup)
        {
            foreach (var target in brokenListeners) ExecuteEvents.Execute<IBrokenCup>(target, null, (x, data) => x.OnBrokenCup(cup));
        }

        public void AddCreateListener(GameObject obj) => createListeners.Add(obj);
        public void RemoveCreateListener(GameObject obj) => createListeners.Remove(obj);
        public void AddCompleteListener(GameObject obj) => completeListeners.Add(obj);
        public void RemoveCompleteListener(GameObject obj) => completeListeners.Remove(obj);
        public void AddBrokenListener(GameObject obj) => brokenListeners.Add(obj);
        public void RemoveBrokenListener(GameObject obj) => brokenListeners.Remove(obj);
    }

}