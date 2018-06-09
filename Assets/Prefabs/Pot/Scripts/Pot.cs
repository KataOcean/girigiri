using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Girigiri
{
    public class Pot : MonoBehaviour
    {
        private Rigidbody2D body;
        private Vector2 nextPosition;
        [SerializeField]
        private PourPosition pourPosition;
        private bool IsWait { get; set; }
        // Use this for initialization
        void Start()
        {
            body = GetComponent<Rigidbody2D>();
            nextPosition = transform.position;
        }

        void FixedUpdate()
        {
            body.MovePosition(nextPosition);
        }
        public void Move(Vector2 position)
        {
            nextPosition = new Vector2(position.x, transform.position.y);
        }

        public void Pour()
        {
            if (pourPosition == null) return;
            if (!pourPosition.canPour) return;
            ChipFactory.Instance?.Create(pourPosition.Position);
        }
    }
}