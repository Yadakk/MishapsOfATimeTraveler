using MOATT.Levels.Health;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MOATT.Levels.Buildings
{
    public class Building : MonoBehaviour, IHealth
    {
        [SerializeField]
        private float maxHealth;

        private float currentHealth;

        public float MaxHealth 
        {
            get => maxHealth;
            set
            {
                if (value == maxHealth) return;
                OnMaxHealthChanged?.Invoke();
                maxHealth = value;
            }
        }

        public float CurrentHealth
        {
            get => currentHealth;
            set
            {
                if (value == currentHealth) return;
                OnHealthChanged?.Invoke();
                currentHealth = value;
            }
        }

        public event Action OnHealthChanged;
        public event Action OnMaxHealthChanged;

        private void Awake()
        {
            CurrentHealth = MaxHealth;
        }
    }
}
