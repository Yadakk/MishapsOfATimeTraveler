using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace MOATT.Levels.Enemies
{
    using Health;

    public class EnemyDeathHandler : IInitializable, System.IDisposable
    {
        private readonly HealthWatcher healthWatcher;
        private readonly EnemyFacade facade;

        public EnemyDeathHandler(HealthWatcher healthWatcher, EnemyFacade facade = null)
        {
            this.healthWatcher = healthWatcher;
            this.facade = facade;
        }

        public void Initialize()
        {
            healthWatcher.OnDied += DiedHandler;
        }

        public void Dispose()
        {
            healthWatcher.OnDied -= DiedHandler;
        }

        private void DiedHandler()
        {
            facade.Destroy();
        }
    }
}
