using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;
using TimeTimers;

namespace MOATT.Levels.Waves.States
{
    using Tiles;

    public class Spawning : State
    {
        private readonly Settings settings;
        private readonly WaveStateMachine stateMachine;
        private readonly Timer timer;
        private readonly SpawnerTileFacade[] spawners;
        private readonly WaveInfo waveInfo;

        private int remainingToSpawn;

        public Spawning(Settings settings, WaveStateMachine stateMachine,
            Timer timer, TileFacade[] tiles, WaveInfo waveInfo)
        {
            this.settings = settings;
            this.stateMachine = stateMachine;
            this.timer = timer;
            spawners = tiles.OfType<SpawnerTileFacade>().ToArray();
            remainingToSpawn = settings.enemiesToSpawn;
            this.waveInfo = waveInfo;
        }

        public override void Update()
        {
            if (remainingToSpawn == 0)
            {
                stateMachine.SetState(StateFactory.EState.EnemiesAlive);
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
            waveInfo.enemies.Add(selectedSpawner.Spawn());
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
