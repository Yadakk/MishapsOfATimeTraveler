using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace MOATT.Levels.Enemies
{
    using Tiles;

    public class EnemyTowerDamager : IInitializable, System.IDisposable
    {
        private readonly EnemyPathfinder navigator;
        private readonly EnemyFacade facade;
        private readonly Settings settings;

        public EnemyTowerDamager(EnemyPathfinder navigator, EnemyFacade facade, Settings settings = null)
        {
            this.navigator = navigator;
            this.facade = facade;
            this.settings = settings;
        }

        public void Initialize()
        {
            navigator.OnTileReached += TileReachedHandler;
        }

        public void Dispose()
        {
            navigator.OnTileReached -= TileReachedHandler;
        }

        private void TileReachedHandler(TileFacade tile)
        {
            if (tile.CurrentBuilding == null) return;
            tile.CurrentBuilding.Damage(settings.damage);
            Object.Destroy(facade.gameObject);
        }

        [System.Serializable]
        public class Settings
        {
            public float damage = 1f;
        }
    }
}
