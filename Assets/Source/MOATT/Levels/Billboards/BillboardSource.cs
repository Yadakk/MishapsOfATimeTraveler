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
        public Vector3 offset;

        private readonly Renderer[] renderers;

        public BillboardSource(Renderer[] renderers, Settings settings)
        {
            this.renderers = renderers;
            offset = settings.offset;
        }

        [Inject]
        public void Initialize()
        {
            UpdateBounds();
        }

        [Inject]
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
