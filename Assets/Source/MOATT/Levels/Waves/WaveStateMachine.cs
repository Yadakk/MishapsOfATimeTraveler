using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

namespace MOATT.Levels.Waves
{
    using States;
    using System;

    public class WaveStateMachine : IInitializable, ITickable
    {
        private readonly StateFactory stateFactory;
        private readonly Settings settings;

        private State currentState;

        public WaveStateMachine(StateFactory stateFactory, Settings settings)
        {
            this.stateFactory = stateFactory;
            this.settings = settings;
        }

        public void Initialize()
        {
            if (settings.startOnInit) SetState<Delay>();
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

        [Serializable]
        public class Settings
        {
            public bool startOnInit = true;
        }
    }
}
