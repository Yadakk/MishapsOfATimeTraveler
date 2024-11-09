using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MOATT.Levels.Health
{
    using Billboards;
    using Zenject;

    public class Healthbar : MonoBehaviour, IBillboard
    {
        private IHealth iHealth;

        private Slider slider;

        public RectTransform RT { get; private set; }

        private void Awake()
        {
            RT = GetComponent<RectTransform>();
            slider = GetComponentInChildren<Slider>();

            iHealth.OnHealthChanged += HealthChangedHandler;
            iHealth.OnMaxHealthChanged += MaxHealthChangedHandler;
        }

        [Inject]
        public void Construct(IHealth iHealth)
        {
            this.iHealth = iHealth;
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

        public class Factory : PlaceholderFactory<IHealth, Healthbar> { }
    }
}
