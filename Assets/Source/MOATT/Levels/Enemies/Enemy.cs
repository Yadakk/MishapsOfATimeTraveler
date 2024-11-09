using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;
using MOATT.Levels.Map.Tiles;

namespace MOATT.Levels.Enemies
{
    public class Enemy : MonoBehaviour
    {
        private Tile[] tiles;
        private MapNavigator navigator;

        private void Awake()
        {
            navigator.OnTileReached += TileReachedHandler;
        }

        private void Start()
        {
            var towerTiles = tiles.Where(tile => tile is TowerTile).ToArray();
            navigator.MoveToTile(towerTiles[Random.Range(0, towerTiles.Length)]);
        }

        [Inject]
        public void Construct(Tile[] tiles, MapNavigator navigator)
        {
            this.tiles = tiles;
            this.navigator = navigator;
        }

        private void TileReachedHandler(Tile tile)
        {
            if (tile.CurrentBuilding == null) return;
            tile.CurrentBuilding.Damage(1);
            Destroy(gameObject);
        }

        public class Factory : PlaceholderFactory<Enemy> { }
    }
}
