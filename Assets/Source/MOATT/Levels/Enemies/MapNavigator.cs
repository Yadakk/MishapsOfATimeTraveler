using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using DG.Tweening;
using System.Linq;
using RndPathfinding;

namespace MOATT.Levels.Enemies
{
    using Map.Tiles;

    public class MapNavigator
    {
        private readonly List<Tile> tiles;
        private readonly Transform transform;
        private readonly Tilemap tilemap;

        public MapNavigator(List<Tile> tiles, Transform transform, 
            Tilemap tilemap)
        {
            this.tiles = tiles;
            this.transform = transform;
            this.tilemap = tilemap;
        }

        public void MoveToTile(Tile target)
        {
            Tile sourceTile = tiles.Find(
                tile => tile.TilemapPos == tilemap.WorldToCell(transform.position));

            List<Tile> tilePath = RndPathfinder.Pathfind(
                tiles.Cast<ICell>().ToList(), sourceTile, target).Cast<Tile>().ToList();

            Vector3[] path = tilePath.Select(tile => tile.WorldPos).ToArray();

            transform.DOPath(path, 1f).SetSpeedBased().SetEase(Ease.Linear);
        }
    }
}
