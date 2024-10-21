using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

namespace MishapsOfATimeTraveler.GameAssembly
{
    public class Enemy : MonoBehaviour
    {
        private Tile[] tiles;
        private MapNavigator navigator;

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

        public class Factory : PlaceholderFactory<Enemy> { }
    }
}
