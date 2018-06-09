using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace Girigiri
{
    public class GUIScore : MonoBehaviour
    {
        [SerializeField]
        private Text TextScore;
        private Score Score;
        // Use this for initialization
        void Start()
        {
            Score = Score.Instance;
            if (Score == null)
            {
                Debug.Log("Score is null");
                Destroy(gameObject);
            }
        }

        // Update is called once per frame
        void Update()
        {
            if (TextScore == null) return;
            TextScore.text = string.Format("{0:C} -", (int)Score.Value);
        }
    }
}