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
            mixer.GetFloat(exposedParamName, out float value);
            slider.value = Mathf.Pow(Mathf.InverseLerp(-80f, 0f, value), 5);
        }

        private void SliderValueChanged(float value)
        {
            mixer.SetFloat(exposedParamName, Mathf.Lerp(-80f, 0f, Mathf.Pow(value, 0.2f)));
        }
    }
}
