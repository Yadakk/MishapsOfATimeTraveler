using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;
using Timers;

namespace MishapsOfATimeTraveler.GameAssembly
{
    public class WaveSpawner : ITickable, IInitializable
    {
        private readonly Settings settings;
        private readonly EnemySpawner[] spawners;

        private State state;
        private Timer timer;
        private int wave;
        private int enemiesToSpawn;
        private int enemyCount;

        public enum State
        {
            WaveDelay,
            Spawning,
            EnemiesAlive,
        }

        public WaveSpawner(Tile[] spawners, Settings settings, Timer timer)
        {
            this.spawners = spawners.OfType<EnemySpawner>().ToArray();
            this.settings = settings;
            this.timer = timer;
        }

        public void Initialize()
        {
            SetState(State.WaveDelay);
            NextWave();
        }

        public void Tick()
        {
            switch(state)
            {
                case State.WaveDelay:

                    break;

                case State.Spawning:

                    break;

                case State.EnemiesAlive:

                    break;
            }
        }

        private void SetState(State newState)
        {
            state = newState;
        }

        private void NextWave()
        {
            wave++;
            enemiesToSpawn = wave;
        }

        private void SpawnEnemy()
        {
            EnemySpawner selectedSpawner = spawners[Random.Range(0, spawners.Length)];
            selectedSpawner.Spawn();
            enemiesToSpawn--;
        }

        [System.Serializable]
        public class Settings
        {
            [field: SerializeField]
            public float EnemySpawnInterval { get; private set; } = 1f;
        }
    }
}
