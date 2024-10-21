using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using MishapsOfATimeTraveler.RndPathfinding;
using Zenject;

namespace MishapsOfATimeTraveler.GameAssembly
{
    public class Tile : MonoBehaviour, ICell
    {
        [SerializeField]
        private bool isWalkable;

        private Tilemap tilemap;

        public Vector2Int CellPos => (Vector2Int)TilemapPos;
        public bool IsWalkable => isWalkable;

        public Vector3Int TilemapPos => tilemap.WorldToCell(WorldPos);
        public Vector3 WorldPos => transform.position;

        [Inject]
        public void Construct(Tilemap tilemap)
        {
            this.tilemap = tilemap;
        }
    }
}