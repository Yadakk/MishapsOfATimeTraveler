using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace MOATT.Levels.Waves.States
{
    public class EnemiesAlive : State
    {
        private readonly WaveInfo waveInfo;
        private readonly WaveStateMachine stateMachine;

        public EnemiesAlive(WaveInfo waveInfo, WaveStateMachine stateMachine)
        {
            this.waveInfo = waveInfo;
            this.stateMachine = stateMachine;
        }

        public override void Update()
        {
            if (waveInfo.CountClearNullEnemies() == 0)
                stateMachine.SetState<Delay>();
        }

        public class Factory : PlaceholderFactory<EnemiesAlive> { }
    }
}
