using BoundsMeasurement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace MOATT.Levels.Billboards
{
    public class BillboardSource : IInitializable
    {
        public Bounds bounds;
        public Vector3 offset;

        private readonly Renderer[] renderers;

        public BillboardSource(Renderer[] renderers, Settings settings)
        {
            this.renderers = renderers;
            offset = settings.offset;
        }

        public void Initialize()
        {
            bounds = renderers.GetBounds().Value;
        }

        [System.Serializable]
        public class Settings
        {
            public Vector3 offset;
        }
    }
}
