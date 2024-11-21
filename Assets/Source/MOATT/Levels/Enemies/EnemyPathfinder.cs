using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System.Linq;
using RndPathfinding;

namespace MOATT.Levels.Enemies
{
    using Tiles;
    using Zenject;

    public class EnemyPathfinder : IInitializable
    {
        private readonly Settings settings;
        private readonly TileFacade[] tiles;
        private readonly EnemyFacade facade;

        public event System.Action<TileFacade> OnTileReached;
        public event System.Action<TileFacade[]> OnPathCreated;

        public EnemyPathfinder(
            TileFacade[] tiles,
            EnemyFacade facade,
            Settings settings
            )
        {
            this.tiles = tiles;
            this.facade = facade;
            this.settings = settings;
        }

        public void Initialize()
        {
            var towerTiles = tiles.Where(tile => tile is TowerTileFacade).ToArray();
            MoveToTile(towerTiles[Random.Range(0, towerTiles.Length)]);
        }

        public void MoveToTile(TileFacade target)
        {
            TileFacade sourceTile = System.Array.Find(tiles,
                tile => tile.TileCell.TilemapPos == facade.TilemapPos);

            List<TileFacade> tilePath = RndPathfinder.Pathfind(
                tiles.Select(tile => tile.TileCell).
                Cast<ICell>().ToList(), 
                sourceTile.TileCell, target.TileCell).
                Cast<TileCell>().Select(tileCell => tileCell.facade).ToList();

            OnPathCreated?.Invoke(tilePath.ToArray());
            Vector3[] path = tilePath.Select(tile => tile.TileCell.WorldPos).ToArray();

            facade.transform.DOPath(path, settings.speed).SetSpeedBased().SetEase(Ease.Linear).
                OnComplete(() => OnTileReached?.Invoke(target));
        }

        [System.Serializable]
        public class Settings
        {
            public float speed = 1f;
        }
    }
}
