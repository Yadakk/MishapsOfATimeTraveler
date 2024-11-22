using MOATT.Levels.Health;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace MOATT.Levels.Buildings.HealthBuildings
{
    public class BuildingDeathHandler : IInitializable, System.IDisposable
    {
        private readonly HealthWatcher healthWatcher;
        private readonly BuildingFacade facade;

        public BuildingDeathHandler(HealthWatcher healthWatcher, BuildingFacade facade = null)
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
