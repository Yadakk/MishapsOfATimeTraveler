using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MOATT.Levels.Buildings.Bombs
{
    using Enemies;
    using MOATT.Levels.Units.Damage;
    using Units.Range;

    public class BombExploder
    {
        private readonly EnemyRegistry enemyRegistry;
        private readonly BuildingFacade facade;
        private readonly UnitRange unitRange;
        private readonly UnitDamage unitDamage;

        public BombExploder(EnemyRegistry enemyRegistry, BuildingFacade facade, UnitDamage unitDamage, UnitRange unitRange)
        {
            this.enemyRegistry = enemyRegistry;
            this.facade = facade;
            this.unitDamage = unitDamage;
            this.unitRange = unitRange;
        }

        public void Explode()
        {
            foreach (var enemy in enemyRegistry.enemies)
            {
                if (Vector3.Distance(
                    enemy.transform.position,
                    facade.transform.position) > unitRange.Range) continue;

                enemy.Damage(unitDamage.Value);
            }

            facade.Destroy();
        }
    }
}
