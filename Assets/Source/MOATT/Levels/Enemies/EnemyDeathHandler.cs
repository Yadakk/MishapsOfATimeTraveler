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
        private List<AudioClip> deathSounds;
        private UnityEngine.Object oneShotSoundPrefab;
        private System.Random rnd;

        public EnemyDeathHandler(HealthWatcher healthWatcher, EnemyFacade facade, PlayerResources playerResources, Settings settings = null, EnemyExplosionParticleEmitter particleEmitter = null)
        {
            this.healthWatcher = healthWatcher;
            this.facade = facade;
            this.playerResources = playerResources;
            this.settings = settings;
            this.particleEmitter = particleEmitter;
            deathSounds = settings.DeathSounds;
            oneShotSoundPrefab = settings.OneShotSoundPrefab;
            rnd = new();
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
            GameObject instantiatedPrefab = (GameObject)UnityEngine.Object.Instantiate(oneShotSoundPrefab, facade.gameObject.transform.position, Quaternion.identity);
            AudioSource prefabSource = instantiatedPrefab.GetComponent<AudioSource>();
            prefabSource.clip = deathSounds[rnd.Next(0, deathSounds.Count)];
            prefabSource.Play();
            facade.Destroy();
            playerResources.NutsAndBolts += settings.nutsAndBoltsReward;
        }

        [Serializable]
        public class Settings
        {
            public int nutsAndBoltsReward = 50;
            public List<AudioClip> DeathSounds;
            public UnityEngine.Object OneShotSoundPrefab;
        }
    }
}
