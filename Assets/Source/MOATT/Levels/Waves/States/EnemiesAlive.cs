using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace MOATT.Levels.Waves.States
{
    using Enemies;

    public class EnemiesAlive : State
    {
        private readonly EnemyRegistry enemyRegistry;
        private readonly WaveStateMachine stateMachine;
        private readonly WaveInfo waveInfo;

        public EnemiesAlive(EnemyRegistry enemyRegistry, WaveStateMachine stateMachine, WaveInfo waveInfo)
        {
            this.enemyRegistry = enemyRegistry;
            this.stateMachine = stateMachine;
            this.waveInfo = waveInfo;
        }

        public override void Update()
        {
            if (enemyRegistry.enemies.Count != 0) return;
            stateMachine.SetState<Delay>();
            waveInfo.currentWave++;
        }

        public class Factory : PlaceholderFactory<EnemiesAlive> { }
    }
}
