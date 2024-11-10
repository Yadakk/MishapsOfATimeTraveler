using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace MOATT.Levels.Enemies
{
    using Map.Tiles;

    public class EnemyTowerDamager : IInitializable, System.IDisposable
    {
        private readonly EnemyPathfinder navigator;
        private readonly EnemyFacade facade;

        public EnemyTowerDamager(EnemyPathfinder navigator, EnemyFacade facade)
        {
            this.navigator = navigator;
            this.facade = facade;
        }

        [Inject]
        public void Initialize()
        {
            navigator.OnTileReached += TileReachedHandler;
        }

        [Inject]
        public void Dispose()
        {
            navigator.OnTileReached -= TileReachedHandler;
        }

        private void TileReachedHandler(Tile tile)
        {
            if (tile.CurrentBuilding == null) return;
            tile.CurrentBuilding.Damage(1);
            Object.Destroy(facade.gameObject);
        }
    }
}
