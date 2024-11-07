using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MOATT.Levels.Waves
{
    using States;

    public class StateFactory
    {
        private readonly Delay.Factory delay;
        private readonly Spawning.Factory spawning;
        private readonly EnemiesAlive.Factory enemiesAlive;

        public StateFactory(Delay.Factory delay, Spawning.Factory spawning, EnemiesAlive.Factory enemiesAlive)
        {
            this.delay = delay;
            this.spawning = spawning;
            this.enemiesAlive = enemiesAlive;
        }

        public enum EState
        {
            Delay,
            Spawning,
            EnemiesAlive,
        }

        public State Create(EState state)
        {
            return state switch
            {
                EState.Delay => delay.Create(),
                EState.Spawning => spawning.Create(),
                EState.EnemiesAlive => enemiesAlive.Create(),
                _ => throw new System.NotImplementedException()
            };
        }
    }
}
