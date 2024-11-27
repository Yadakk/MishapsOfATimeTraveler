using MOATT.Levels.Buildings.Spikes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using Cannedenuum.ZenjectUtils.MonoInterfaces;

namespace MOATT.Levels.Buildings.Fence
{
    using Enemies;

    public class FenceUnitBlocker : IUpdatable, System.IDisposable
    {
        private readonly EnemyRegistry enemyRegistry;
        private readonly BuildingTunables tunables;
        private readonly BuildingFacade buildingFacade;

        public FenceUnitBlocker(
            EnemyRegistry enemyRegistry,
            BuildingTunables tunables,
            BuildingFacade buildingFacade = null)
        {
            this.enemyRegistry = enemyRegistry;
            this.tunables = tunables;
            this.buildingFacade = buildingFacade;
        }

        public BuildingFacade BuildingFacade => buildingFacade;

        public void Update()
        {
            foreach (var enemy in enemyRegistry.enemies)
            {
                if (tunables.initTile.TileCell.TilemapPos == enemy.TilemapPos && !enemy.IsFlying)
                    enemy.Pathfinder.RegisterBlocker(this);
                else
                    enemy.Pathfinder.UnregisterBlocker(this);
            }
        }

        public void Dispose()
        {
            foreach (var enemy in enemyRegistry.enemies)
            {
                enemy.Pathfinder.UnregisterBlocker(this);
            }
        }
    }
}
