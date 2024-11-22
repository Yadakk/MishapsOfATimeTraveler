using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace MOATT.Levels.Billboards
{
    public class BillboardPositioner : IInitializable, ITickable
    {
        public readonly BillboardFacade facade;
        private readonly Camera camera;
        private readonly BillboardSource source;

        public BillboardPositioner(BillboardSource source, Camera camera, BillboardFacade facade)
        {
            this.source = source;
            this.camera = camera;
            this.facade = facade;
        }

        public void Initialize()
        {
            UpdatePosition();
        }

        public void Tick()
        {
            UpdatePosition();
        }

        public void UpdatePosition()
        {
            Vector3 displayerTop = source.Bounds.center;
            displayerTop.y = source.Bounds.max.y;
            displayerTop += source.Offset;
            facade.transform.position = camera.WorldToScreenPoint(displayerTop);
        }
    }
}
