using MOATT.Levels.Range;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace MOATT.Levels.UnitRange
{
    public class UnitRange
    {
        private readonly Settings settings;
        private readonly Tilemap tilemap;

        public UnitRange(Settings settings, Tilemap tilemap = null)
        {
            this.settings = settings;
            this.tilemap = tilemap;
        }

        public float Range => UnitTilemapRangeGetter.GetRange(tilemap, settings.rangeTiles);

        [Serializable]
        public class Settings
        {
            public float rangeTiles = 1f;
        }
    }
}
