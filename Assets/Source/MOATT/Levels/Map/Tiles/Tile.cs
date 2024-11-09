using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using RndPathfinding;
using Zenject;

namespace MOATT.Levels.Map.Tiles
{
    using Buildings;

    public class Tile : MonoBehaviour, ICell
    {
        [SerializeField]
        private bool isWalkable;

        private Tilemap tilemap;

        public Building CurrentBuilding { get; private set; }

        public Vector2Int CellPos => (Vector2Int)TilemapPos;
        public bool IsWalkable => isWalkable;

        public Vector3Int TilemapPos => tilemap.WorldToCell(WorldPos);
        public Vector3 WorldPos => transform.position;

        [Inject]
        public void Construct(Tilemap tilemap, [InjectOptional] Building building)
        {
            this.tilemap = tilemap;
            CurrentBuilding = building;
        }
        
        public void ConstructOptional(Tilemap tilemap, Building building)
        {
            this.tilemap = tilemap;
            CurrentBuilding = building;
        }
    }
}