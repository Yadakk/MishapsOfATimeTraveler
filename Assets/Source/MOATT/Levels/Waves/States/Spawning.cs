﻿using System.Collections;
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
        private readonly SpawnChanceDistribution spawnChanceDistribution;

        private int remainingToSpawn;

        public Spawning(Settings settings, WaveStateMachine stateMachine,
            Timer timer, TileFacade[] tiles, EnemyRegistry enemyRegistry, SpawnChanceDistribution spawnChanceDistribution)
        {
            this.settings = settings;
            this.stateMachine = stateMachine;
            this.timer = timer;
            this.enemyRegistry = enemyRegistry;

            spawners = tiles.OfType<SpawnerTileFacade>().ToArray();
            remainingToSpawn = settings.enemiesToSpawn;
            this.spawnChanceDistribution = spawnChanceDistribution;
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
        }
    }
}
