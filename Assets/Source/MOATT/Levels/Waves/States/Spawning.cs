using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using MOATT.Levels.Map.Tiles;
using TimeTimers;

namespace MOATT.Levels.Waves.States
{
    public class Spawning : State
    {
        private readonly Settings settings;
        private readonly WaveStateMachine stateMachine;
        private readonly Factory factory;
        private readonly Timer timer;
        private readonly EnemySpawner[] spawners;

        private int remainingToSpawn;

        public Spawning(Settings settings, WaveStateMachine stateMachine, Factory factory,
            Timer timer, EnemySpawner[] spawners)
        {
            this.settings = settings;
            this.stateMachine = stateMachine;
            this.factory = factory;
            this.timer = timer;
            this.spawners = spawners;
            remainingToSpawn = settings.enemiesToSpawn;
        }

        public override void Update()
        {
            if (remainingToSpawn == 0)
            {
                stateMachine.SetState(factory.Create());
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
