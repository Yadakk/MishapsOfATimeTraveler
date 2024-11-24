using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MOATT.Levels.Buildings.Bombs
{
    using Enemies;
    using UnitRanges;

    public class BombExploder
    {
        private readonly EnemyRegistry enemyRegistry;
        private readonly BuildingFacade facade;
        private readonly Settings settings;
        private readonly UnitRange unitRange;

        public BombExploder(EnemyRegistry enemyRegistry, BuildingFacade facade = null, Settings settings = null, UnitRange unitRange = null)
        {
            this.enemyRegistry = enemyRegistry;
            this.facade = facade;
            this.settings = settings;
            this.unitRange = unitRange;
        }

        public void Explode()
        {
            foreach (var enemy in enemyRegistry.enemies)
            {
                if (Vector3.Distance(
                    enemy.transform.position,
                    facade.transform.position) > unitRange.Range) continue;

                enemy.Damage(settings.damage);
            }
            facade.Destroy();
        }

        [System.Serializable]
        public class Settings
        {
            public float damage = 200f;
        }
    }
}
