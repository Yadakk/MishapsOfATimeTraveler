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
        private readonly EnemyRegistry enemyRegistry;
        private readonly SpikesReloader spikesReloader;
        private readonly BuildingFacade facade;

        public SpikesEnemyDamager(
            Settings settings,
            EnemyRegistry enemyRegistry,
            SpikesReloader spikesReloader,
            BuildingFacade facade)
        {
            this.settings = settings;
            this.enemyRegistry = enemyRegistry;
            this.spikesReloader = spikesReloader;
            this.facade = facade;
        }

        public void Tick()
        {
            if (!facade.isActiveAndEnabled) return;
            var enemies = enemyRegistry.enemies;

            foreach (var enemy in enemies)
            {
                if (facade.CurrentTile.TileCell.TilemapPos != enemy.TilemapPos) continue;
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
