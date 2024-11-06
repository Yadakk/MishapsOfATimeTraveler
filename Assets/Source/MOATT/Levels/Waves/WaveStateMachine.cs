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
        private readonly Delay.Factory delayFactory;

        private State state;

        public WaveStateMachine(Delay.Factory delayFactory)
        {
            this.delayFactory = delayFactory;
        }

        public void Initialize()
        {
            SetState(delayFactory.Create());
        }

        public void Tick()
        {
            state?.Update();
        }

        public void SetState(State newState)
        {
            state?.Dispose();
            state = newState;
            state?.Start();
        }
    }
}
