using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Girigiri
{
    public class Overlap : MonoBehaviour
    {
        [SerializeField]
        private LayerMask targetLayer;
        [SerializeField]
        private float radius = 0.2f;

        public bool isOverlap { get; private set; } = false;
        // Use this for initialization

        // Update is called once per frame
        void Update()
        {
            var col = Physics2D.OverlapCircle(transform.position, radius, targetLayer);
            isOverlap = col != null;
        }

        void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, radius);
        }
    }
}