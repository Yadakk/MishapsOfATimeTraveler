using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace MOATT.Levels.Healthbars
{
    using Health;

    public class HealthbarVM : IInitializable, System.IDisposable
    {
        private readonly HealthModel model;
        private readonly Slider slider;

        public HealthbarVM(HealthModel model, Slider slider)
        {
            this.model = model;
            this.slider = slider;
        }

        public void Initialize()
        {
            model.OnHealthChanged += HealthChangedHandler;
            model.OnMaxHealthChanged += MaxHealthChangedHandler;

            ViewMax();
            ViewCurrent();
        }

        public void Dispose()
        {
            model.OnHealthChanged -= HealthChangedHandler;
            model.OnMaxHealthChanged -= MaxHealthChangedHandler;
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
    }
}
