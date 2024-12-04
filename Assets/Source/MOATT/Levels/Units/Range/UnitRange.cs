using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MOATT.Levels.Units.Range
{
    using TilemapSizeMultipliers;

    public class UnitRange
    {
        private readonly Settings settings;
        private readonly TilemapSizeMultiplier tilemapSizeMultiplier;

        public UnitRange(Settings settings, TilemapSizeMultiplier tilemapSizeMultiplier)
        {
            this.settings = settings;
            this.tilemapSizeMultiplier = tilemapSizeMultiplier;
        }

        public float Range => tilemapSizeMultiplier.Multiply(settings.rangeTiles);

        [Serializable]
        public class Settings
        {
            public float rangeTiles = 1f;
        }
    }
}
