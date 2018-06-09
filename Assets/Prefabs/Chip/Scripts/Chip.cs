using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Girigiri
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Chip : MonoBehaviour
    {
        [SerializeField]
        private float size = 1.0f;
        public float Size => size * Scale;
        [SerializeField]
        private float stoppableTime = 0.5f; //この時間以上経過したら静止判定を始める
        public bool IsStop
        {
            get
            {
                if (DropTimer < stoppableTime) return false;
                if (body == null) return true;
                var velocity = body.velocity;
                return body.IsSleeping() || (Mathf.Abs(velocity.x) <= stopVelocity && Mathf.Abs(velocity.y) <= stopVelocity);
            }
        }
        private Rigidbody2D body;
        [SerializeField]
        private float stopVelocity = 0.1f;
        public ChipFactory ChipFactory { get; set; }
        private float DropTimer { get; set; } = 0.0f;
        private float BrokenTimer { get; set; } = 0.0f;
        private bool IsBroken { get; set; } = false;
        const float BROKEN_TIME = 5.0f;
        private float Scale { get; set; }
        [SerializeField]
        private AudioClip hitClip;
        private bool IsHit { get; set; } = false;
        // Use this for initialization
        void Start()
        {
            body = GetComponent<Rigidbody2D>();
            if (body == null)
            {
                Debug.Log("Rigidbody2d is null");
                Destroy(gameObject);
            }
            Scale = Random.Range(0.8f, 1.2f);
            transform.localScale = new Vector2(Scale, Scale);
        }
        // Update is called once per frame
        void Update()
        {
            DropTimer += Time.deltaTime;
            if (IsBroken)
            {
                BrokenTimer += Time.deltaTime;
                if (BrokenTimer > BROKEN_TIME) Destroy(gameObject);
            }
            if (!IsHit && IsStop) PlayHit();
        }

        void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.GetComponent<Ground>() != null)
            {
                ChipFactory?.Remove(this);
                Destroy(gameObject);
            }
            else if (collision.gameObject.GetComponent<CupEdge>() != null)
            {
                PlayHit();
            }
        }

        void PlayHit()
        {
            if (!IsHit)
            {
                SE.Instance?.Play(hitClip);
                IsHit = true;
            }
        }

        public void Broken()
        {
            if (gameObject == null) return;
            var sr = GetComponent<SpriteRenderer>();
            if (sr != null) sr.sortingLayerName = "Back";
            IsBroken = true;
            BrokenTimer = 0.0f;
            if (body != null) body.AddForce(new Vector2(UnityEngine.Random.Range(-640.0f, 640.0f), 640.0f));
            gameObject.layer = LayerMask.NameToLayer("InActive");
        }
        public void Fix()
        {
            body.bodyType = RigidbodyType2D.Static;
        }
    }
}
