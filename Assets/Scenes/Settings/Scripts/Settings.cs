using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Girigiri
{
    public class Settings : MonoBehaviour
    {
        public static float BGMVolume = 0.7f;
        public static float SEVolume = 0.7f;
        [SerializeField]
        public Slider BGMSlider;
        [SerializeField]
        public Slider SESlider;
        // Use this for initialization
        void Start()
        {
            BGMVolume = PlayerPrefs.GetFloat(nameof(BGMVolume), 0.7f);
            SEVolume = PlayerPrefs.GetFloat(nameof(SEVolume), 0.7f);
            if (BGMSlider != null) BGMSlider.value = BGMVolume;
            if (SESlider != null) SESlider.value = SEVolume;
        }
        public void ChangeBGMVolume(float value)
        {
            BGMVolume = Mathf.Clamp(value, 0.0f, 1.0f);
            PlayerPrefs.SetFloat(nameof(BGMVolume), BGMVolume);
        }

        public void ChangeSEVolume(float value)
        {
            SEVolume = Mathf.Clamp(value, 0.0f, 1.0f);
            PlayerPrefs.SetFloat(nameof(SEVolume), SEVolume);
        }
    }
}