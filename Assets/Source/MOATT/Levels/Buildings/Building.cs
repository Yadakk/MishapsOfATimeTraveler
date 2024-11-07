using MOATT.Levels.Health;
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
            set => maxHealth = value;
        }

        public float CurrentHealth 
        { 
            get => currentHealth;
            set => currentHealth = value; 
        }

        private void Awake()
        {
            CurrentHealth = MaxHealth;
        }
    }
}
