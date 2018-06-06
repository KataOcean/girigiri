using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Girigiri
{
    public class PourPosition : MonoBehaviour
    {
        [SerializeField]
        private Overlap overlap;
        public bool canPour { get; private set; } = true;
        public Vector2 Position => new Vector2(transform.position.x, transform.position.y);
        // Use this for initialization
        void Start()
        {
            if (overlap == null)
            {
                Debug.Log("Overlap is null.");
                Destroy(gameObject);
            }
        }

        // Update is called once per frame
        void Update()
        {
            canPour = !overlap.isOverlap;
        }
    }
}
