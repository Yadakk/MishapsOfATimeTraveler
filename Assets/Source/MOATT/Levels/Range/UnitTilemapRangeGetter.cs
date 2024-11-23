using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace MOATT.Levels.Range
{
    public static class UnitTilemapRangeGetter
    {
        public static float GetRange(Tilemap tilemap, float range)
        {
            return range * tilemap.cellSize.x;
        }
    }
}
