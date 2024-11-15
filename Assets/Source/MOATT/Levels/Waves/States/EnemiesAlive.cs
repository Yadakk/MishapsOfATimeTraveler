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

        public EnemiesAlive(EnemyRegistry enemyRegistry, WaveStateMachine stateMachine)
        {
            this.enemyRegistry = enemyRegistry;
            this.stateMachine = stateMachine;
        }

        public override void Update()
        {
            if (enemyRegistry.enemies.Count == 0)
                stateMachine.SetState<Delay>();
        }

        public class Factory : PlaceholderFactory<EnemiesAlive> { }
    }
}
