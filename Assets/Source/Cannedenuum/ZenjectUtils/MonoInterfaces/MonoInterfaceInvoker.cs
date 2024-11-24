using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Cannedenuum.ZenjectUtils.MonoInterfaces
{
    public class MonoInterfaceInvoker : MonoBehaviour
    {
        private IStartable[] startables;
        private IEnableable[] enableables;
        private IDisableable[] disableables;
        private IUpdatable[] updatables;

        [Inject]
        public void Construct(
            [Inject(Optional = true, Source = InjectSources.Local)] IStartable[] startables,
            [Inject(Optional = true, Source = InjectSources.Local)] IEnableable[] enableables,
            [Inject(Optional = true, Source = InjectSources.Local)] IDisableable[] disableables,
            [Inject(Optional = true, Source = InjectSources.Local)] IUpdatable[] updatables
            )
        {
            this.startables = startables;
            this.enableables = enableables;
            this.disableables = disableables;
            this.updatables = updatables;
        }

        private void Start()
        {
            if (startables == null) return;
            foreach (var startable in startables) startable.Start();
        }

        private void Update()
        {
            if (updatables == null) return;
            foreach (var updateable in updatables) updateable.Update();
        }

        private void OnEnable()
        {
            if (enableables == null) return;
            foreach (var enableable in enableables) enableable.OnEnable();
        }

        private void OnDisable()
        {
            if (disableables == null) return;
            foreach (var disableable in disableables) disableable.OnDisable();
        }
    }
}
