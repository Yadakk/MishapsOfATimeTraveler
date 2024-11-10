using log4net.Util;
using MOATT.Levels.Buildings;
using RndPathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace MOATT.Levels.Tiles
{
    public class TileCell : ICell
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

        public Vector2Int CellPos => (Vector2Int)TilemapPos;
        public bool IsWalkable => settings.isWalkable;

        public Vector3Int TilemapPos => tilemap.WorldToCell(WorldPos);
        public Vector3 WorldPos => facade.transform.position;

        [System.Serializable]
        public class Settings
        {
            public bool isWalkable;
        }
    }
}
