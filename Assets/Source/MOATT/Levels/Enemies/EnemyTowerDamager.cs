using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using Cannedenuum.ZenjectUtils.MonoInterfaces;

namespace MOATT.Levels.Enemies
{
    using Tiles;
    using Buildings;
    using Units.Damage;

    public class EnemyTowerDamager : IInitializable, System.IDisposable, IUpdatable
    {
        private readonly EnemyPathfinder navigator;
        private readonly UnitDamage unitDamage;
        private readonly EnemyReloader reloader;

        private BuildingFacade tower;

        public EnemyTowerDamager(EnemyPathfinder navigator, EnemyReloader reloader = null, UnitDamage unitDamage = null)
        {
            this.navigator = navigator;
            this.reloader = reloader;
            this.unitDamage = unitDamage;
        }

        public void Initialize()
        {
            navigator.OnTileReached += TileReachedHandler;
        }

        public void Dispose()
        {
            navigator.OnTileReached -= TileReachedHandler;
        }

        public void Update()
        {
            if (tower == null) return;
            if (!reloader.ReadyToAttack) return;
            tower.Damage(unitDamage.Value);
            reloader.ReadyToAttack = false;
        }

        private void TileReachedHandler(TileFacade tile)
        {
            var building = tile.CurrentBuilding;
            if (building == null) return;
            if (building.HealthModel == null) return;
            tower = building;
        }
    }
}
