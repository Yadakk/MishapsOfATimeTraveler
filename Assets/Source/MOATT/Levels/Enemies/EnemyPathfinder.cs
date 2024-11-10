using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using DG.Tweening;
using System.Linq;
using RndPathfinding;

namespace MOATT.Levels.Enemies
{
    using Tiles;
    using Zenject;

    public class EnemyPathfinder : IInitializable
    {
        private readonly Tile[] tiles;
        private readonly EnemyFacade facade;
        private readonly Tilemap tilemap;

        public event System.Action<Tile> OnTileReached;

        public EnemyPathfinder(
            Tile[] tiles,
            EnemyFacade facade, 
            Tilemap tilemap)
        {
            this.tiles = tiles;
            this.facade = facade;
            this.tilemap = tilemap;
        }

        public void Initialize()
        {
            var towerTiles = tiles.Where(tile => tile is TowerTile).ToArray();
            MoveToTile(towerTiles[Random.Range(0, towerTiles.Length)]);
        }

        public void MoveToTile(Tile target)
        {
            Tile sourceTile = System.Array.Find(tiles,
                tile => tile.TilemapPos == tilemap.WorldToCell(facade.transform.position));

            List<Tile> tilePath = RndPathfinder.Pathfind(
                tiles.Cast<ICell>().ToList(), sourceTile, target).Cast<Tile>().ToList();

            Vector3[] path = tilePath.Select(tile => tile.WorldPos).ToArray();

            facade.transform.DOPath(path, 1f).SetSpeedBased().SetEase(Ease.Linear).
                OnComplete(() => OnTileReached?.Invoke(target));
        }
    }
}
