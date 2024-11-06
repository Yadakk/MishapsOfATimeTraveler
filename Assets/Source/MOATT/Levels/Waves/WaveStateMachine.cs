using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;
using TimeTimers;
using MOATT.Levels.Waves.States;

namespace MOATT.Levels.Waves
{
    public class WaveStateMachine : ITickable
    {
        private readonly StateFactory stateFactory;

        private State state;

        public WaveStateMachine(StateFactory stateFactory)
        {
            this.stateFactory = stateFactory;
        }

        public void Tick()
        {
            state?.Update();
        }

        public void SetState(StateFactory.States newState)
        {
            state?.Dispose();
            state = stateFactory.Create(newState);
            state?.Start();
        }
    }
}
