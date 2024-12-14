using MOATT.Levels.GameplayConditions;
using MOATT.Levels.Health;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace MOATT.Levels.Buildings.Tower
{
    public class TowerLostInvoker : IInitializable, IDisposable
    {
        private readonly HealthWatcher healthWatcher;
        private readonly LevelLostInvoker levelLostInvoker;

        public TowerLostInvoker(HealthWatcher healthWatcher, LevelLostInvoker levelLostInvoker)
        {
            this.healthWatcher = healthWatcher;
            this.levelLostInvoker = levelLostInvoker;
        }

        public void Initialize()
        {
            healthWatcher.OnDied += DiedHandler;
        }

        public void Dispose()
        {
            healthWatcher.OnDied -= DiedHandler;
        }

        private void DiedHandler()
        {
            levelLostInvoker.InvokeLose();
            Debug.Log("Invok");
        }
    }
}
