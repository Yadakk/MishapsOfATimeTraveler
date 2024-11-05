using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using MOATT.Map.Tiles;
using TimeTimers;

namespace MOATT.Map.Waves.States
{
    public class Spawning : State
    {
        private readonly Settings settings;
        private readonly Timer timer;
        private readonly EnemySpawner[] spawners;
        private readonly WaveStateMachine stateMachine;

        private int remainingToSpawn;

        public Spawning(Settings settings, WaveStateMachine stateMachine,
            Timer timer, EnemySpawner[] spawners)
        {
            this.settings = settings;
            this.timer = timer;
            this.spawners = spawners;
            this.stateMachine = stateMachine;
            remainingToSpawn = settings.enemiesToSpawn;
        }

        public override void Update()
        {
            if (remainingToSpawn == 0)
            {
                stateMachine.SetState(StateFactory.States.EnemiesAlive);
            }

            if (timer.Elapsed >= settings.spawnInterval)
            {
                SpawnEnemy();
                timer.Reset();
            }
        }

        private void SpawnEnemy()
        {
            EnemySpawner selectedSpawner = spawners[Random.Range(0, spawners.Length)];
            selectedSpawner.Spawn();
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
