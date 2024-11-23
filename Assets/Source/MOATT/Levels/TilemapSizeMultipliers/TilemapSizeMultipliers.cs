using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace MOATT.Levels.TilemapSizeMultipliers
{
    public class TilemapSizeMultiplier
    {
        private readonly Tilemap tilemap;

        public TilemapSizeMultiplier(Tilemap tilemap)
        {
            this.tilemap = tilemap;
        }

        public float Multiply(float value)
        {
            return value * tilemap.cellSize.x;
        }
    }
}
