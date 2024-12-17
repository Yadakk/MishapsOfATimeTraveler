using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace MOATT.Sound
{
    public class MixerSlider : MonoBehaviour
    {
        [SerializeField] private AudioMixer mixer;
        [SerializeField] private string exposedParamName;
        [SerializeField] private Slider slider;

        private void Awake()
        {
            slider.onValueChanged.AddListener(SliderValueChanged);
        }

        private void Start()
        {
            if (!mixer.GetFloat(exposedParamName, out float value)) 
                throw new Exception($"mixer has no param called {exposedParamName}");
            slider.value = value;
        }

        private void SliderValueChanged(float value)
        {
            if (!mixer.SetFloat(exposedParamName, value))
                throw new Exception($"mixer has no param called {exposedParamName}");
        }
    }
}
