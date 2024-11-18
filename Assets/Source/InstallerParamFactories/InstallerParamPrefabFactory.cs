using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace InstallerParamFactories
{
    public class InstallerParamPrefabFactory<P1, TInstaller, T> : IFactory<Object, P1, T> where T : Component
    {
        private readonly DiContainer container;

        public InstallerParamPrefabFactory(DiContainer container)
        {
            this.container = container;
        }

        public T Create(Object prefab, P1 param1)
        {
            T gameObject = Object.Instantiate(prefab) as T;
            Debug.Log(gameObject);
            var subContext = gameObject.GetComponent<GameObjectContext>();
            //subContext.Install<>
            subContext.Container.BindInstance(param1).WhenInjectedInto<TInstaller>();
            subContext.Run();
            container.InjectGameObject(gameObject.gameObject);
            return subContext.Container.Resolve<T>();
        }
    }
}
