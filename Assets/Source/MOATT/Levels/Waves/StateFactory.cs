using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MOATT.Levels.Waves.States;
using Zenject;

namespace MOATT.Levels.Waves
{
    public class StateFactory
    {
        private readonly Delay.Factory delay;
        private readonly Spawning.Factory spawning;
        private readonly EnemiesAlive.Factory enemiesAlive;

        public enum States
        {
            Delay,
            Spawning,
            EnemiesAlive,
        }

        public StateFactory(Delay.Factory delay, Spawning.Factory spawning, EnemiesAlive.Factory enemiesAlive)
        {
            this.delay = delay;
            this.spawning = spawning;
            this.enemiesAlive = enemiesAlive;
        }

        public State Create(States state)
        {
            return state switch
            {
                States.Delay => delay.Create(),
                States.Spawning => spawning.Create(),
                States.EnemiesAlive => enemiesAlive.Create(),
                _ => throw new System.NotImplementedException(),
            };
        }
    }
}
