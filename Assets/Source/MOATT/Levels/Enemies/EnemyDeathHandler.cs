using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace MOATT.Levels.Enemies
{
    using Health;
    using Economics;

    public class EnemyDeathHandler : IInitializable, IDisposable
    {
        private readonly HealthWatcher healthWatcher;
        private readonly EnemyFacade facade;
        private readonly PlayerResources playerResources;
        private readonly Settings settings;
        private readonly EnemyExplosionParticleEmitter particleEmitter;

        public EnemyDeathHandler(HealthWatcher healthWatcher, EnemyFacade facade, PlayerResources playerResources, Settings settings = null, EnemyExplosionParticleEmitter particleEmitter = null)
        {
            this.healthWatcher = healthWatcher;
            this.facade = facade;
            this.playerResources = playerResources;
            this.settings = settings;
            this.particleEmitter = particleEmitter;
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
            particleEmitter.EmitParticles();
            facade.Destroy();
            playerResources.NutsAndBolts += settings.nutsAndBoltsReward;
        }

        [Serializable]
        public class Settings
        {
            public int nutsAndBoltsReward = 50;
        }
    }
}
