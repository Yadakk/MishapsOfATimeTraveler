using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using BoundsMeasurement;

namespace MOATT.Levels.BoundsCalculation
{
    public class BoundsCalculator : ITickable
    {
        private readonly Renderer[] renderers;

        public BoundsCalculator(Renderer[] renderers)
        {
            this.renderers = renderers;
        }

        public Bounds Bounds { get; private set; }

        public void Tick()
        {
            Bounds = renderers.GetBounds();
        }
    }
}
