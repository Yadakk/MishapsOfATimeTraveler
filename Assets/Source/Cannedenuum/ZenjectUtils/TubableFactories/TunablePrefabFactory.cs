using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

namespace Cannedenuum.ZenjectUtils.Factories
{
    public class TunablePrefabFactory<TTunables, T> : IFactory<Object, TTunables, T> where T : Component
    {
        private readonly DiContainer container;

        public TunablePrefabFactory(DiContainer container)
        {
            this.container = container;
        }

        public T Create(Object prefab, TTunables tunables)
        {
            var subContainer = container.CreateSubContainer();
            subContainer.BindInstance(tunables);
            return subContainer.InstantiatePrefabForComponent<T>(prefab);
        }
    }
}
