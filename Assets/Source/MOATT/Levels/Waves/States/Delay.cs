using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using TimeTimers;

namespace MOATT.Levels.Waves.States
{
    public class Delay : State
    {
        private readonly Settings settings;
        private readonly Timer timer;
        private readonly WaveStateMachine stateMachine;

        public Delay(Timer timer, Settings settings, WaveStateMachine stateMachine)
        {
            this.timer = timer;
            this.settings = settings;
            this.stateMachine = stateMachine;
        }

        public override void Update()
        {
            if (timer.Elapsed > settings.waveDelay)
                stateMachine.SetState(StateFactory.EState.Spawning);
        }

        public class Factory : PlaceholderFactory<Delay> { }

        [System.Serializable]
        public class Settings
        {
            public float waveDelay = 1f;
        }
    }
}

