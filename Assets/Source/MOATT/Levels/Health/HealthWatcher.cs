using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace MOATT.Levels.Health
{
    public class HealthWatcher : IInitializable
    {
        private readonly HealthModel healthModel;

        public event System.Action OnDied;

        public HealthWatcher(HealthModel healthModel)
        {
            this.healthModel = healthModel;
        }

        public void Initialize()
        {
            healthModel.OnHealthChanged += HealthChangedHandler;
        }

        private void HealthChangedHandler()
        {
            if (healthModel.CurrentHealth <= 0)
            {
                OnDied?.Invoke();
            }
        }
    }
}
