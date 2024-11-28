using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cannedenuum.ZenjectUtils.MonoInterfaces;

namespace MOATT.Levels.Buildings.Fence
{
    using Enemies;
    using static UnityEngine.EventSystems.EventTrigger;

    public class FenceUnitBlocker : IUpdatable, IDisposable
    {
        private readonly EnemyRegistry enemyRegistry;
        private readonly BuildingTunables tunables;
        private readonly BuildingFacade buildingFacade;

        private readonly List<EnemyFacade> tempIgnored = new();

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
            CheckTempIgnored();

            foreach (var enemy in enemyRegistry.enemies)
            {
                if (tempIgnored.Contains(enemy)) return;
                if (tunables.initTile.TileCell.TilemapPos == enemy.TilemapPos && !enemy.IsFlying)
                {
                    if (enemy.Pathfinder.FenceIgnoreCount > 0)
                    {
                        enemy.Pathfinder.FenceIgnoreCount--;
                        tempIgnored.Add(enemy);
                        continue;
                    }
                    enemy.Pathfinder.RegisterBlocker(this);
                }
                else enemy.Pathfinder.UnregisterBlocker(this);
            }
        }

        public void Dispose()
        {
            foreach (var enemy in enemyRegistry.enemies)
            {
                enemy.Pathfinder.UnregisterBlocker(this);
            }
        }

        private void CheckTempIgnored()
        {
            tempIgnored.RemoveAll(enemy => tunables.initTile.TileCell.TilemapPos != enemy.TilemapPos);
        }
    }
}
