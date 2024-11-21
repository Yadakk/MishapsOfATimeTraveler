using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using Zenject;

namespace MOATT.Levels.Enemies
{
    public class EnemyTilemapPositionCalculator : IInitializable, ITickable
    {
        private readonly Tilemap tilemap;
        private readonly EnemyFacade facade;

        public EnemyTilemapPositionCalculator(Tilemap tilemap, EnemyFacade facade)
        {
            this.tilemap = tilemap;
            this.facade = facade;
        }

        public Vector3Int TilemapPosition { get; private set; }

        public void Initialize()
        {
            UpdatePosition();
        }

        public void Tick()
        {
            UpdatePosition();
        }

        private void UpdatePosition()
        {
            TilemapPosition = tilemap.WorldToCell(facade.transform.position);
        }
    }
}
