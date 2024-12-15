using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MOATT.Levels.Enemies
{
    public class EnemyRegistry
    {
        public readonly List<EnemyFacade> enemies = new();

        public event Action OnEnemyDied;

        public void Add(EnemyFacade enemy)
        {
            enemies.Add(enemy);
            enemy.HealthWatcher.OnDied += InvokeOnEnemyDied;
        }

        public void Remove(EnemyFacade enemy)
        {
            enemies.Remove(enemy);
            enemy.HealthWatcher.OnDied -= InvokeOnEnemyDied;
        }

        private void InvokeOnEnemyDied() => OnEnemyDied?.Invoke();
    }
}