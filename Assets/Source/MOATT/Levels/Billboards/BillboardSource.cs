using BoundsMeasurement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace MOATT.Levels.Billboards
{
    using BoundsCalculation;

    public class BillboardSource
    {
        private readonly BoundsCalculator boundsCalculator;
        private readonly Settings settings;

        public BillboardSource(BoundsCalculator boundsCalculator, Settings settings)
        {
            this.boundsCalculator = boundsCalculator;
            this.settings = settings;
        }

        public Bounds Bounds => boundsCalculator.Bounds;
        public Vector3 Offset => settings.offset; 

        [System.Serializable]
        public class Settings
        {
            public Vector3 offset;
        }
    }
}
