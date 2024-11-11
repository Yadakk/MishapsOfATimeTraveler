using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

namespace MOATT.Levels.Waves
{
    using States;

    public class WaveStateMachine : IInitializable, ITickable
    {
        private readonly StateFactory stateFactory;

        private State currentState;

        public WaveStateMachine(StateFactory stateFactory)
        {
            this.stateFactory = stateFactory;
        }

        public void Initialize()
        {
            SetState<Delay>();
        }

        public void Tick()
        {
            currentState?.Update();
        }

        public void SetState<T>() where T : State
        {
            currentState?.Dispose();
            currentState = stateFactory.Create(typeof(T));
            currentState?.Start();
        }
    }
}
