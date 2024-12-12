using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using Cannedenuum.ZenjectUtils.MonoInterfaces;

namespace MOATT.Levels.Buildings.Spikes
{
    using Enemies;
    using MOATT.Levels.Units.Damage;

    public class SpikesEnemyDamager : IUpdatable
    {
        private readonly UnitDamage unitDamage;
        private readonly EnemyRegistry enemyRegistry;
        private readonly SpikesReloader spikesReloader;
        private readonly BuildingTunables tunables;

        public SpikesEnemyDamager(
            UnitDamage unitDamage,
            EnemyRegistry enemyRegistry,
            SpikesReloader spikesReloader,
            BuildingTunables tunables)
        {
            this.unitDamage = unitDamage;
            this.enemyRegistry = enemyRegistry;
            this.spikesReloader = spikesReloader;
            this.tunables = tunables;
        }

        public void Update()
        {
            var enemies = enemyRegistry.enemies;

            foreach (var enemy in enemies)
            {
                if (tunables.initTile.TileCell.TilemapPos != enemy.TilemapPos) continue;
                if (enemy.IsFlying) continue;
                if (!spikesReloader.IsReady) continue;

                enemy.Damage(unitDamage.Value);
                spikesReloader.IsReady = false;
            }
        }
    }
}
