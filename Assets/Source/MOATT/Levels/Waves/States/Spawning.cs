using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;
using TimeTimers;

namespace MOATT.Levels.Waves.States
{
    using Tiles;
    using Enemies;

    public class Spawning : State
    {
        private readonly Settings settings;
        private readonly WaveStateMachine stateMachine;
        private readonly Timer timer;
        private readonly SpawnerTileFacade[] spawners;
        private readonly EnemyRegistry enemyRegistry;

        private int remainingToSpawn;

        public Spawning(Settings settings, WaveStateMachine stateMachine,
            Timer timer, TileFacade[] tiles, EnemyRegistry enemyRegistry)
        {
            this.settings = settings;
            this.stateMachine = stateMachine;
            this.timer = timer;
            this.enemyRegistry = enemyRegistry;

            spawners = tiles.OfType<SpawnerTileFacade>().ToArray();
            remainingToSpawn = settings.enemiesToSpawn;
        }

        public override void Update()
        {
            if (remainingToSpawn == 0)
            {
                stateMachine.SetState<EnemiesAlive>();
            }

            if (timer.Elapsed >= settings.spawnInterval)
            {
                SpawnEnemy();
                timer.Reset();
            }
        }

        private void SpawnEnemy()
        {
            var enemyPrefabs = settings.enemyPrefabs;
            SpawnerTileFacade selectedSpawner = spawners[Random.Range(0, spawners.Length)];
            selectedSpawner.Spawn(enemyPrefabs[Random.Range(0, enemyPrefabs.Length)]);
            remainingToSpawn--;
        }

        public class Factory : PlaceholderFactory<Spawning> { }

        [System.Serializable]
        public class Settings
        {
            public EnemyFacade[] enemyPrefabs;
            public float spawnInterval = 1f;
            public int enemiesToSpawn = 5;
        }
    }
}
