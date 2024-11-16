using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace MOATT.Levels.Buildings.Turrets
{
    using Enemies;
    using System.Linq;

    public class TurretTargetPicker : ITickable
    {
        private readonly Settings settings;
        private readonly EnemyRegistry registry;
        private readonly BuildingFacade facade;

        public TurretTargetPicker(EnemyRegistry registry, Settings settings = null, BuildingFacade facade = null)
        {
            this.registry = registry;
            this.settings = settings;
            this.facade = facade;
        }

        public EnemyFacade Enemy { get; private set; }

        public void Tick()
        {
            Enemy = registry.enemies.FirstOrDefault(enemy => Vector3.Distance(
                facade.transform.position, enemy.transform.position) <= settings.range);
        }

        [System.Serializable]
        public class Settings
        {
            public float range = 6f;
        }
    }
}
