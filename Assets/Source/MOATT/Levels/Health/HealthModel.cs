using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MOATT.Levels.Health
{
    public class HealthModel
    {
        private float currentHealth;
        private float maxHealth;

        public event System.Action OnHealthChanged;
        public event System.Action OnMaxHealthChanged;

        public HealthModel(Settings settings)
        {
            maxHealth = settings.maxHealth;
            currentHealth = settings.maxHealth;
        }

        public float MaxHealth
        {
            get => maxHealth;
            set
            {
                if (value == maxHealth) return;
                maxHealth = value;
                OnMaxHealthChanged?.Invoke();
            }
        }

        public float CurrentHealth
        {
            get => currentHealth;
            set
            {
                if (value == currentHealth) return;
                currentHealth = value;
                if (currentHealth > MaxHealth) currentHealth = MaxHealth;
                OnHealthChanged?.Invoke();
            }
        }

        [System.Serializable]
        public class Settings
        {
            public float maxHealth = 100f;
        }
    }
}
