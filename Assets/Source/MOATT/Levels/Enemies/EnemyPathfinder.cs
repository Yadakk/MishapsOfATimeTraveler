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
    using TilemapSizeMultipliers;

    public class EnemyPathfinder : IInitializable
    {
        public readonly List<object> blockers = new();

        private readonly Settings settings;
        private readonly TileFacade[] tiles;
        private readonly EnemyFacade facade;
        private readonly TilemapSizeMultiplier tilemapSizeMultiplier;

        private int fenceIgnoreCount;
        private Tweener pathTweener;

        public event System.Action<TileFacade> OnTileReached;
        public event System.Action<TileFacade[]> OnPathCreated;
        public event System.Action OnFenceIgnoreCountChanged;

        public EnemyPathfinder(
            TileFacade[] tiles,
            EnemyFacade facade,
            Settings settings,
            TilemapSizeMultiplier tilemapSizeMultiplier = null)
        {
            this.tiles = tiles;
            this.facade = facade;
            this.settings = settings;
            this.tilemapSizeMultiplier = tilemapSizeMultiplier;

            fenceIgnoreCount = settings.fenceIgnoreCount;
        }

        public int FenceIgnoreCount
        {
            get => fenceIgnoreCount;
            set
            {
                fenceIgnoreCount = value;
                OnFenceIgnoreCountChanged?.Invoke();
            }
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

            List<ICell> cellMap = tiles.Select(tile => tile.TileCell).Cast<ICell>().ToList();
            List<ICell> cellPath = RndPathfinder.Pathfind(cellMap, sourceTile.TileCell, target.TileCell);
            List<TileFacade> tilePath = cellPath.Cast<TileCell>().Select(tileCell => tileCell.facade).ToList();
            tilePath.RemoveAt(tilePath.Count - 1);

            OnPathCreated?.Invoke(tilePath.ToArray());
            Vector3[] path = tilePath.Select(tile => tile.TileCell.WorldPos).ToArray();

            pathTweener = facade.transform.DOPath(path, tilemapSizeMultiplier.Multiply(settings.tilesPerSecond)).
                SetSpeedBased().SetEase(Ease.Linear).OnComplete(() => OnTileReached?.Invoke(target));
        }

        public void RegisterBlocker(object obj)
        {
            if (blockers.Contains(obj)) return;
            blockers.Add(obj);
            if (blockers.Count > 0) pathTweener.timeScale = 0f;
        }

        public void UnregisterBlocker(object obj)
        {
            if (!blockers.Contains(obj)) return;
            blockers.Remove(obj);
            if (blockers.Count == 0) pathTweener.timeScale = 1f;
        }

        [System.Serializable]
        public class Settings
        {
            public float tilesPerSecond = 1f;
            public int fenceIgnoreCount = 0;
        }
    }
}
