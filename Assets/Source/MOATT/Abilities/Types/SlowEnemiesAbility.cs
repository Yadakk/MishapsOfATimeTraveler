using MOATT.Levels.Enemies;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace MOATT.Abilities.Types
{
    public class SlowEnemiesAbility : Ability, IInitializable, IDisposable
    {
        private readonly Settings settings;
        private readonly Description description;
        private readonly EnemyRegistry enemyRegistry;

        public SlowEnemiesAbility(AbilityActiveDuration abilityActiveDuration, Settings settings, Description description, EnemyRegistry enemyRegistry)
        {
            AbilityActiveDuration = abilityActiveDuration;
            this.settings = settings;
            this.description = description;
            this.enemyRegistry = enemyRegistry;
        }

        public void Initialize()
        {
            AbilityActiveDuration.duration = settings.duration;
            AbilityActiveDuration.OnActiveChanged += ActiveChangedHandler;
        }

        public void Dispose()
        {
            AbilityActiveDuration.OnActiveChanged -= ActiveChangedHandler;
        }

        public override void Activate()
        {
            AbilityActiveDuration.Activate();
        }

        public override string ToString() => description.ToString();

        private void ActiveChangedHandler(bool value)
        {
            if (value)
            {
                enemyRegistry.OnEnemyAdded += AddMultipliersToEnemy;
                for (int i = 0; i < enemyRegistry.enemies.Count; i++)
                {
                    AddMultipliersToEnemy(enemyRegistry.enemies[i]);
                }
            }
            else
            {
                enemyRegistry.OnEnemyAdded -= AddMultipliersToEnemy;
                for (int i = 0; i < enemyRegistry.enemies.Count; i++)
                {
                    enemyRegistry.enemies[i].Reloader.RemoveMultiplier(this);
                    enemyRegistry.enemies[i].Pathfinder.RemoveMultiplier(this);
                }
            }
        }

        private void AddMultipliersToEnemy(EnemyFacade enemy)
        {
            enemy.Reloader.AddMultiplier(this, settings.multiplier);
            enemy.Pathfinder.AddMultiplier(this, settings.multiplier);
        }

        [Serializable]
        public class Settings
        {
            public float duration = 30f;
            public float multiplier = 0.5f;
        }

        public class Description
        {
            public override string ToString()
            {
                return "All enemies walk and attack twice as slow for 30 seconds";
            }
        }
    }
}
