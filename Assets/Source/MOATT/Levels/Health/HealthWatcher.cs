using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace MOATT.Levels.Health
{
    public class HealthWatcher : IInitializable
    {
        private readonly HealthModel healthModel;
        private readonly GameObject gameObject;

        public event System.Action OnDied;

        public HealthWatcher(HealthModel healthModel, GameObject gameObject)
        {
            this.healthModel = healthModel;
            this.gameObject = gameObject;
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
                Object.Destroy(gameObject);
            }
        }
    }
}
