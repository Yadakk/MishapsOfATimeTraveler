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

        private bool enabled = true;

        public BillboardPositioner(BillboardSource source, Camera camera, BillboardFacade facade)
        {
            this.source = source;
            this.camera = camera;
            this.facade = facade;
        }

        public bool Enabled
        {
            get => enabled;
            set
            {
                enabled = value;
                facade.gameObject.SetActive(enabled);
            }
        }

        public void Initialize()
        {
            UpdatePosition();
        }

        public void Tick()
        {
            if (!Enabled) return;
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
