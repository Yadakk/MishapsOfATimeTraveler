using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using Cannedenuum.ZenjectUtils.MonoInterfaces;

namespace MOATT.Levels.Buildings.Spikes
{
    using Enemies;
    using MOATT.Levels.Units.Damage;
    using System;

    public class SpikesEnemyDamager : IUpdatable
    {
        private readonly UnitDamage unitDamage;
        private readonly EnemyRegistry enemyRegistry;
        private readonly SpikesReloader spikesReloader;
        private readonly BuildingTunables tunables;
        private readonly AudioSource source;
        private readonly Settings settings;

        public SpikesEnemyDamager(
            UnitDamage unitDamage,
            EnemyRegistry enemyRegistry,
            SpikesReloader spikesReloader,
            BuildingTunables tunables,
            AudioSource source,
            Settings settings)
        {
            this.unitDamage = unitDamage;
            this.enemyRegistry = enemyRegistry;
            this.spikesReloader = spikesReloader;
            this.tunables = tunables;
            this.source = source;
            this.settings = settings;
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
                source.PlayOneShot(settings.clip);
                spikesReloader.IsReady = false;
            }
        }

        [Serializable]
        public class Settings
        {
            public AudioClip clip;
        }
    }
}
