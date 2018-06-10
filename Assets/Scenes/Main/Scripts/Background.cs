using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Girigiri
{
    public class Background : MonoBehaviour
    {
        [SerializeField]
        private float speed = 0.5f;
        Vector2 BasePosition { get; set; }

        // Use this for initialization
        void Start()
        {
            BasePosition = new Vector2(transform.position.x, transform.position.y);
        }

        // Update is called once per frame
        void Update()
        {
            if (transform.position.x > 20.0f)
            {
                transform.position = new Vector2(0.0f, 0.0f);
            }
            transform.Translate(Vector2.right * (speed * Time.deltaTime));
        }
    }
}
