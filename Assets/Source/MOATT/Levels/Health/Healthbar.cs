using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MOATT.Levels.Health
{
    using Zenject;

    public class Healthbar : MonoBehaviour
    {
        private HealthModel model;

        private Slider slider;

        private void Awake()
        {
            slider = GetComponentInChildren<Slider>();

            model.OnHealthChanged += HealthChangedHandler;
            model.OnMaxHealthChanged += MaxHealthChangedHandler;

            ViewMax();
            ViewCurrent();
        }

        [Inject]
        public void Construct(HealthModel model)
        {
            this.model = model;
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
            slider.value = model.CurrentHealth;
        }

        private void ViewMax()
        {
            slider.maxValue = model.MaxHealth;
        }

        public class Factory : PlaceholderFactory<HealthModel, Healthbar> { }
    }
}
