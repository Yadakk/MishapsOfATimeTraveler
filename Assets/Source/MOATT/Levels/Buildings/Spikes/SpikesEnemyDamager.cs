using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace MOATT.Levels.Buildings.Spikes
{
    using Enemies;

    public class SpikesEnemyDamager : ITickable
    {
        private readonly Settings settings;
        private readonly BuildingTunables tunables;
        private readonly EnemyRegistry enemyRegistry;
        private readonly SpikesReloader spikesReloader;

        public SpikesEnemyDamager(
            Settings settings,
            BuildingTunables tunables,
            EnemyRegistry enemyRegistry,
            SpikesReloader spikesReloader)
        {
            this.settings = settings;
            this.tunables = tunables;
            this.enemyRegistry = enemyRegistry;
            this.spikesReloader = spikesReloader;
        }

        public void Tick()
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
