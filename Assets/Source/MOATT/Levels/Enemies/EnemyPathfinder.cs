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
    using Healthbars;

    public class EnemyPathfinder : IInitializable
    {
        private readonly TileFacade[] tiles;
        private readonly EnemyFacade facade;
        private readonly Tilemap tilemap;

        public event System.Action<TileFacade> OnTileReached;
        public event System.Action<TileFacade[]> OnPathCreated;

        public EnemyPathfinder(
            TileFacade[] tiles,
            EnemyFacade facade,
            Tilemap tilemap)
        {
            this.tiles = tiles;
            this.facade = facade;
            this.tilemap = tilemap;
        }

        public void Initialize()
        {
            var towerTiles = tiles.Where(tile => tile is TowerTileFacade).ToArray();
            MoveToTile(towerTiles[Random.Range(0, towerTiles.Length)]);
        }

        public void MoveToTile(TileFacade target)
        {
            TileFacade sourceTile = System.Array.Find(tiles,
                tile => tile.TileCell.TilemapPos == tilemap.WorldToCell(facade.transform.position));

            List<TileFacade> tilePath = RndPathfinder.Pathfind(
                tiles.Select(tile => tile.TileCell).
                Cast<ICell>().ToList(), 
                sourceTile.TileCell, target.TileCell).
                Cast<TileCell>().Select(tileCell => tileCell.facade).ToList();

            OnPathCreated?.Invoke(tilePath.ToArray());
            Vector3[] path = tilePath.Select(tile => tile.TileCell.WorldPos).ToArray();

            facade.transform.DOPath(path, 1f).SetSpeedBased().SetEase(Ease.Linear).
                OnComplete(() => OnTileReached?.Invoke(target));
        }
    }
}
