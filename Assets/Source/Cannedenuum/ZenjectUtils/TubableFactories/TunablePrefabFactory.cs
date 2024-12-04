using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;
using Cannedenuum.ZenjectUtils.TransformGrouping;

namespace Cannedenuum.ZenjectUtils.TubableFactories
{
    public class TunablePrefabFactory<TTunables, T> : IFactory<Object, TTunables, T> where T : Component
    {
        private readonly DiContainer container;
        private readonly RootTransformGrouper rootTransformGrouper;
        private readonly string groupName;

        public TunablePrefabFactory(DiContainer container, [InjectOptional] RootTransformGrouper rootTransformGrouper, [InjectOptional] string groupName)
        {
            this.container = container;
            this.rootTransformGrouper = rootTransformGrouper;
            this.groupName = groupName;
        }

        public T Create(Object prefab, TTunables tunables)
        {
            var subContainer = container.CreateSubContainer();
            subContainer.BindInstance(tunables);
            T instantiatedComponent = subContainer.InstantiatePrefabForComponent<T>(prefab);
            if (groupName != null && rootTransformGrouper != null) MoveGameObjectToGroup(instantiatedComponent);
            return instantiatedComponent;
        }
        
        private void MoveGameObjectToGroup(T component)
        {
            component.transform.SetParent(rootTransformGrouper.GetGroup(groupName));
        }
    }
}
