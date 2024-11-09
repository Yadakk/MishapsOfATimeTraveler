using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace MOATT.Levels.Billboards
{
    public class Billboard
    {
        private readonly Camera camera;
        private readonly IDisplayer iDisplayer;
        private readonly IBillboard iBillboard;

        public Billboard(IDisplayer iDisplayer, Camera camera, IBillboard iBillboard = null)
        {
            this.iDisplayer = iDisplayer;
            this.camera = camera;
            this.iBillboard = iBillboard;
        }

        public void Update()
        {
            Vector3 displayerTop = iDisplayer.Bounds.center;
            displayerTop.y = iDisplayer.Bounds.max.y + iDisplayer.DisplayHeight;
            iBillboard.RT.position = camera.WorldToScreenPoint(displayerTop);
        }

        public class Factory : PlaceholderFactory<IDisplayer, IBillboard, Billboard> { }
    }
}
