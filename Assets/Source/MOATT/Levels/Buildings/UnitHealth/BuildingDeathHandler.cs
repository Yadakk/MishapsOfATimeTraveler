using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace MOATT.Levels.Buildings.UnitHealth
{
    using Health;

    public class BuildingDeathHandler : IInitializable, System.IDisposable
    {
        private readonly HealthWatcher healthWatcher;
        private readonly BuildingFacade facade;

        public BuildingDeathHandler(
            [InjectOptional] HealthWatcher healthWatcher, 
            BuildingFacade facade = null)
        {
            this.healthWatcher = healthWatcher;
            this.facade = facade;
        }

        public void Initialize()
        {
            if (healthWatcher == null) return;
            healthWatcher.OnDied += DiedHandler;
        }

        public void Dispose()
        {
            if (healthWatcher == null) return;
            healthWatcher.OnDied -= DiedHandler;
        }

        private void DiedHandler()
        {
            facade.Destroy();
        }
    }
}
