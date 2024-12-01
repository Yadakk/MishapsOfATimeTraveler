using RndPathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using Zenject;

namespace MOATT.Levels.Tiles
{
    public class TileCell : IInitializable, ICell
    {
        public readonly TileFacade facade;
        private readonly Settings settings;
        private readonly Tilemap tilemap;

        public TileCell(TileFacade facade, Settings settings = null, Tilemap tilemap = null)
        {
            this.facade = facade;
            this.settings = settings;
            this.tilemap = tilemap;
        }

        public Vector2Int CellPos { get; private set; }
        public bool IsWalkable => settings.isWalkable;

        public Vector3Int TilemapPos { get; private set; }
        public Vector3 WorldPos { get; private set; }

        public void Initialize()
        {
            WorldPos = facade.transform.position;
            TilemapPos = tilemap.WorldToCell(WorldPos);
            CellPos = (Vector2Int)TilemapPos;
        }

        [System.Serializable]
        public class Settings
        {
            public bool isWalkable;
        }
    }
}
