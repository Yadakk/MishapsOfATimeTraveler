using MOATT.Levels.Enemies;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace MOATT.Levels.Buildings.Turrets
{
    public class TurretRotater : ITickable
    {
        private readonly EnemyRegistry registry;
        private readonly BuildingFacade facade;

        public TurretRotater(EnemyRegistry registry, BuildingFacade facade = null)
        {
            this.registry = registry;
            this.facade = facade;
        }

        public void Tick()
        {
            if (registry.enemies.Count == 0) return;
            var transform = facade.transform;
            EnemyFacade firstEnemy = registry.enemies[0];
            Vector3 enemyDirection = firstEnemy.transform.position - transform.position;
            transform.rotation = Quaternion.LookRotation(enemyDirection);
            transform.rotation = Quaternion.Euler(0f, transform.rotation.eulerAngles.y, 0f);
        }
    }
}
