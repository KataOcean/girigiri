using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Girigiri
{
    public class BGM : MonoBehaviour
    {
        private AudioSource AudioSource;
        // Use this for initialization
        void Start()
        {
            AudioSource = GetComponent<AudioSource>();
            AudioSource.volume = Settings.BGMVolume;
        }
        void OnDestroy()
        {
            AudioSource.Stop();
        }
    }

}
