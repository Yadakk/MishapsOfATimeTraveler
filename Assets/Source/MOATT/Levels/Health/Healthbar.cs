using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MOATT.Levels.Health
{
    public class Healthbar : MonoBehaviour
    {
        public IHealth iHealth;

        private Slider slider;

        private void Awake()
        {
            slider = GetComponentInChildren<Slider>();

            iHealth.OnHealthChanged += HealthChangedHandler;
            iHealth.OnMaxHealthChanged += MaxHealthChangedHandler;
        }

        private void HealthChangedHandler()
        {
            ViewCurrent();
        }

        private void MaxHealthChangedHandler()
        {
            ViewMax();
        }

        private void ViewCurrent()
        {
            slider.value = iHealth.CurrentHealth;
        }

        private void ViewMax()
        {
            slider.value = iHealth.MaxHealth;
        }
    }
}
