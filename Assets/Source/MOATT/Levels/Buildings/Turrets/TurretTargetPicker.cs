using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;
using Cannedenuum.ZenjectUtils.MonoInterfaces;

namespace MOATT.Levels.Buildings.Turrets
{
    using Enemies;
    using Units.Range;

    public class TurretTargetPicker : IUpdatable
    {
        private readonly EnemyRegistry registry;
        private readonly BuildingFacade facade;
        private readonly UnitRange unitRange;

        public TurretTargetPicker(EnemyRegistry registry, BuildingFacade facade = null, UnitRange unitRange = null)
        {
            this.registry = registry;
            this.facade = facade;
            this.unitRange = unitRange;
        }

        public EnemyFacade Enemy { get; private set; }

        public void Update()
        {
            Enemy = registry.enemies.FirstOrDefault(enemy => Vector3.Distance(
                facade.transform.position, enemy.transform.position) <= unitRange.Range);
        }
    }
}
