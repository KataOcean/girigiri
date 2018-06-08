using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Girigiri
{
    public class CupEdge : MonoBehaviour
    {
        private Rigidbody2D body;
        private bool IsBroken { get; set; } = false;
        private float BrokenTimer { get; set; } = 0.0f;
        const float BROKEN_TIME = 4.0f;
        void Update()
        {
            if (IsBroken)
            {
                BrokenTimer += Time.deltaTime;
                if (BrokenTimer > BROKEN_TIME) Destroy(gameObject);

            }
        }
        // Use this for initialization
        public void Broken()
        {
            if (IsBroken) return;
            BrokenTimer = 0.0f;
            if (body == null) body = gameObject.AddComponent<Rigidbody2D>();
            body.AddForce(new Vector2(UnityEngine.Random.Range(-320.0f, 320.0f), 320.0f));
            transform.SetParent(null);
            gameObject.layer = LayerMask.NameToLayer("InActive");
            IsBroken = true;
        }
    }
}
