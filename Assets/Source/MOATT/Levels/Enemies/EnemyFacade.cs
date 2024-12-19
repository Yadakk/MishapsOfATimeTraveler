using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;
using DG.Tweening;
using Object = UnityEngine.Object;

namespace MOATT.Levels.Enemies
{
    using Health;
    using BoundsCalculation;
    using MOATT.Levels.Billboards;

    public class EnemyFacade : MonoBehaviour
    {
        private HealthModel healthModel;
        private HealthWatcher healthWatcher;
        private EnemyRegistry registry;
        private BoundsCalculator boundsCalculator;
        private EnemyTilemapPositionCalculator enemyCellPositionCalculator;
        private EnemyPathfinder pathfinder;
        private Settings settings;
        private AudioSource audioSource;
        private List<AudioClip> spawnSounds;
        private System.Random rnd;

        public event Action OnDestroyed;

        public Vector3 Center => boundsCalculator.Bounds.center;
        public Vector3Int TilemapPos => enemyCellPositionCalculator.TilemapPosition;
        public EnemyPathfinder Pathfinder => pathfinder;
        public bool IsFlying => settings.isFlying;
        public HealthWatcher HealthWatcher => healthWatcher;
        public AudioSource AudioSource => audioSource;
        public EnemyPathHistory EnemyPathHistory { get; private set; }
        public EnemyReloader Reloader { get; private set; }
        public BillboardSource BillboardSource { get; private set; }
        public string Name => settings.name;

        private void Awake()
        {
            registry.Add(this);
            if (spawnSounds.Count < 1)
            {
                audioSource.Play();
            }
            else
            {
                audioSource.PlayOneShot(spawnSounds[rnd.Next(0, spawnSounds.Count)]);
            }
        }

        [Inject]
        public void Construct(
            EnemyTunables tunables,
            HealthModel healthModel,
            EnemyRegistry registry,
            BoundsCalculator boundsCalculator,
            EnemyTilemapPositionCalculator enemyCellPositionCalculator,
            EnemyPathfinder pathfinder,
            Settings settings,
            HealthWatcher healthWatcher,
            EnemyPathHistory enemyPathHistory,
            EnemyReloader reloader,
            BillboardSource billboardSource
            )
        {
            this.healthModel = healthModel;
            this.registry = registry;
            this.boundsCalculator = boundsCalculator;
            this.enemyCellPositionCalculator = enemyCellPositionCalculator;
            this.pathfinder = pathfinder;
            this.settings = settings;
            this.healthWatcher = healthWatcher;
            EnemyPathHistory = enemyPathHistory;
            Reloader = reloader;
            BillboardSource = billboardSource;
            spawnSounds = settings.SpawnSounds;
            audioSource = GetComponent<AudioSource>();
            rnd = new();

            transform.position = tunables.initPos;
        }

        public void Damage(float damage)
        {
            healthModel.CurrentHealth -= damage;
        }

        public void Destroy()
        {
            Destroy(gameObject);
        }

        private void OnDestroy()
        {
            transform.DOKill();
            registry.Remove(this);
            OnDestroyed?.Invoke();
        }

        [System.Serializable]
        public class Settings
        {
            public string name;
            public bool isFlying = false;
            public List<AudioClip> SpawnSounds;
        }

        public class Factory : PlaceholderFactory<Object, EnemyTunables, EnemyFacade> { }
    }
}
