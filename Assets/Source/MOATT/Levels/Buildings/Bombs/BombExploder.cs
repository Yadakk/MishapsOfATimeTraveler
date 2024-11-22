using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MOATT.Levels.Buildings.Bombs
{
    using Enemies;

    public class BombExploder
    {
        private readonly EnemyRegistry enemyRegistry;
        private readonly BuildingFacade facade;
        private readonly Settings settings;

        public BombExploder(EnemyRegistry enemyRegistry, BuildingFacade facade = null, Settings settings = null)
        {
            this.enemyRegistry = enemyRegistry;
            this.facade = facade;
            this.settings = settings;
        }

        public void Explode()
        {
            foreach (var enemy in enemyRegistry.enemies)
            {
                if (Vector3.Distance(
                    enemy.transform.position,
                    facade.transform.position) > settings.range) continue;

                enemy.Damage(settings.damage);
                facade.Destroy();
            }
        }

        [System.Serializable]
        public class Settings
        {
            public float range = 4f;
            public float damage = 200f;
        }
    }
}
