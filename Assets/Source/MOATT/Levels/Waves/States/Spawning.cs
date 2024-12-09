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
        private readonly SpawnChanceDistribution spawnChanceDistribution;
        private readonly WaveInfo waveInfo;

        private int remainingToSpawn;

        public Spawning(Settings settings, WaveStateMachine stateMachine,
            Timer timer, TileFacade[] tiles, SpawnChanceDistribution spawnChanceDistribution, WaveInfo waveInfo)
        {
            this.settings = settings;
            this.stateMachine = stateMachine;
            this.timer = timer;
            this.spawnChanceDistribution = spawnChanceDistribution;
            spawners = tiles.OfType<SpawnerTileFacade>().ToArray();
            this.waveInfo = waveInfo;
        }

        public override void Start()
        {
            remainingToSpawn = Mathf.RoundToInt(
                settings.enemiesToSpawn * Mathf.Pow(settings.waveMultiplier, waveInfo.currentWave - 1));
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
            SpawnerTileFacade selectedSpawner = spawners[Random.Range(0, spawners.Length)];
            selectedSpawner.Spawn(spawnChanceDistribution.GetRandomEnemy());
            remainingToSpawn--;
        }

        public class Factory : PlaceholderFactory<Spawning> { }

        [System.Serializable]
        public class Settings
        {
            public float spawnInterval = 1f;
            public int enemiesToSpawn = 5;
            public float waveMultiplier = 1.5f;
        }
    }
}
