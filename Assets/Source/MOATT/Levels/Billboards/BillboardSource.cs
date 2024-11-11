using BoundsMeasurement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace MOATT.Levels.Billboards
{
    public class BillboardSource : IInitializable, ITickable
    {
        public Bounds bounds;

        private readonly Renderer[] renderers;
        private readonly Settings settings;

        public BillboardSource(Renderer[] renderers, Settings settings)
        {
            this.renderers = renderers;
            this.settings = settings;
        }

        public Vector3 Offset => settings.offset;

        public void Initialize()
        {
            UpdateBounds();
        }

        public void Tick()
        {
            UpdateBounds();
        }

        private void UpdateBounds()
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
