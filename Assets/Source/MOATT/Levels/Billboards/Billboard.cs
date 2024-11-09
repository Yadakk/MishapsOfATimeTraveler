using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace MOATT.Levels.Billboards
{
    public class Billboard
    {
        public readonly Transform transform;
        private readonly Camera camera;
        private readonly BillboardSource source;

        public Billboard(BillboardSource source, Camera camera, Transform transform)
        {
            this.source = source;
            this.camera = camera;
            this.transform = transform;
        }

        public void Update()
        {
            Vector3 displayerTop = source.bounds.center;
            displayerTop.y = source.bounds.max.y;
            displayerTop += source.offset;
            transform.position = camera.WorldToScreenPoint(displayerTop);
        }

        public class Factory : PlaceholderFactory<BillboardSource, Transform, Billboard> { }
    }
}
