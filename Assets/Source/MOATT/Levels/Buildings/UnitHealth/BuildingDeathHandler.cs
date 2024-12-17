using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace MOATT.Levels.Buildings.UnitHealth
{
    using Health;
    using MOATT.Particles;

    public class BuildingDeathHandler : IInitializable, System.IDisposable
    {
        private readonly HealthWatcher healthWatcher;
        private readonly BuildingFacade facade;
        private readonly OneShotParticle explosionPrefab;

        public BuildingDeathHandler(
            OneShotParticle explosionPrefab,
            [InjectOptional] HealthWatcher healthWatcher,
            BuildingFacade facade = null
            )
        {
            this.healthWatcher = healthWatcher;
            this.facade = facade;
            this.explosionPrefab = explosionPrefab;
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
            Object.Instantiate(explosionPrefab, facade.transform.position, Quaternion.identity, facade.transform.parent);
            facade.Destroy();
        }
    }
}
