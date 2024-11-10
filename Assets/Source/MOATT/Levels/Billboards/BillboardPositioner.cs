using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace MOATT.Levels.Billboards
{
    public class BillboardPositioner : ITickable
    {
        public readonly Transform transform;
        private readonly Camera camera;
        private readonly BillboardSource source;

        public BillboardPositioner(BillboardSource source, Camera camera, BillboardFacade facade)
        {
            this.source = source;
            this.camera = camera;
            transform = facade.transform;
        }

        [Inject]
        public void Tick()
        {
            Vector3 displayerTop = source.bounds.center;
            displayerTop.y = source.bounds.max.y;
            displayerTop += source.offset;
            transform.position = camera.WorldToScreenPoint(displayerTop);
        }
    }
}
