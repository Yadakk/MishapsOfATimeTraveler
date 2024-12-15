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
    using Health;
    using UnityEngine.UI;
    using System;

    public class EnemyTowerDamager : IInitializable, System.IDisposable, IUpdatable
    {
        private readonly EnemyPathfinder navigator;
        private readonly UnitDamage unitDamage;
        private readonly EnemyReloader reloader;
        private readonly HealthModel healthModel;
        private readonly EnemyFacade facade;
        private readonly Settings settings;

        private BuildingFacade tower;

        public EnemyTowerDamager(EnemyPathfinder navigator, EnemyReloader reloader = null, UnitDamage unitDamage = null, HealthModel healthModel = null, Settings settings = null, EnemyFacade facade = null)
        {
            this.navigator = navigator;
            this.reloader = reloader;
            this.unitDamage = unitDamage;
            this.healthModel = healthModel;
            this.settings = settings;
            this.facade = facade;
        }

        public void Initialize()
        {
            navigator.OnTileReached += TileReachedHandler;
        }

        public void Dispose()
        {
            navigator.OnTileReached -= TileReachedHandler;
            navigator.OnPositionChanged -= PositionChangedHandler;
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
            navigator.OnPositionChanged += PositionChangedHandler;
            var building = tile.CurrentBuilding;
            if (building == null) return;
            if (building.HealthModel == null) return;
            if (settings.selfDestruct)
            {
                building.Damage(healthModel.CurrentHealth);
                facade.Destroy();
            }
            else tower = building;
        }

        private void PositionChangedHandler()
        {
            tower = null;
        }

        [Serializable]
        public class Settings
        {
            public bool selfDestruct = false;
        }
    }
}
