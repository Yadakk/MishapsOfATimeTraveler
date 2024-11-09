using MOATT.Levels.Billboards;
using MOATT.Levels.Health;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MOATT.Levels.Buildings
{
    using BoundsMeasurement;
    using Zenject;

    public class Building : MonoBehaviour, IHealth, IDisplayer
    {
        [SerializeField]
        private float maxHealth = 100;

        private BillboardDisplaySettings billboardDisplaySettings;

        private Billboard.Factory billboardFactory;
        private Healthbar.Factory healthbarFactory;
        private Renderer[] renderers;

        private Billboard billboard;
        private float currentHealth;

        public event Action OnHealthChanged;
        public event Action OnMaxHealthChanged;

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

        public Bounds Bounds { get; private set; }
        public float DisplayHeight => billboardDisplaySettings.displayHeight;

        private void Awake()
        {
            renderers = GetComponentsInChildren<Renderer>();
            CurrentHealth = MaxHealth;
            Bounds = renderers.GetBounds().Value;
        }

        private void Start()
        {
            billboard = billboardFactory.Create(this, healthbarFactory.Create(this));
        }

        private void Update()
        {
            billboard.Update();
        }

        [Inject]
        public void Construct(Billboard.Factory billboardFactory, Healthbar.Factory healthbarFactory, BillboardDisplaySettings billboardDisplaySettings)
        {
            this.billboardFactory = billboardFactory;
            this.healthbarFactory = healthbarFactory;
            this.billboardDisplaySettings = billboardDisplaySettings;
        }

        public void Damage(int damage)
        {
            CurrentHealth -= damage;
            if (CurrentHealth <= 0) Destroy(gameObject);
        }
    }
}
