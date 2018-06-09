using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Girigiri
{
    public class SE : MonoBehaviour
    {
        public static SE Instance { get; private set; }
        private AudioSource AudioSource;
        void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else Destroy(gameObject);
        }
        // Use this for initialization
        void Start()
        {
            AudioSource = GetComponent<AudioSource>();
        }

        public void Play(AudioClip clip)
        {
            if (AudioSource == null) return;
            AudioSource.PlayOneShot(clip, Settings.SEVolume);
        }
    }
}
