using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MOATT.Levels.Waves
{
    using States;
    using Zenject;

    public class StateFactory : IFactory<System.Type, State>
    {
        private readonly DiContainer container;

        public StateFactory(DiContainer container = null)
        {
            this.container = container;
        }

        public State Create(System.Type type)
        {
            return (State)container.Instantiate(type);
        }
    }
}
