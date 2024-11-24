using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using Cannedenuum.ZenjectUtils.MonoInterfaces;

namespace MOATT.Levels.Buildings.Spikes
{
    using Enemies;

    public class SpikesEnemyDamager : IUpdatable
    {
        private readonly Settings settings;
        private readonly EnemyRegistry enemyRegistry;
        private readonly SpikesReloader spikesReloader;
        private readonly BuildingTunables tunables;

        public SpikesEnemyDamager(
            Settings settings,
            EnemyRegistry enemyRegistry,
            SpikesReloader spikesReloader,
            BuildingTunables tunables)
        {
            this.settings = settings;
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
                if (!spikesReloader.IsReady) continue;

                enemy.Damage(settings.baseDamage);
                spikesReloader.IsReady = false;
            }
        }

        [System.Serializable]
        public class Settings
        {
            public float baseDamage = 10f;
        }
    }
}
