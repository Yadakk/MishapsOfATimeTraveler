using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using static Zenject.CheatSheet;

namespace MOATT.Levels.Billboards
{
    public class BillboardPositioner : IInitializable, ITickable
    {
        public readonly BillboardFacade facade;
        private readonly Camera camera;
        private readonly BillboardSource source;
        private readonly Transform cameraTransform;

        public BillboardPositioner(BillboardSource source, Camera camera, BillboardFacade facade)
        {
            this.source = source;
            this.camera = camera;
            this.facade = facade;
            cameraTransform = camera.transform;
        }

        public void Initialize()
        {
            UpdatePosition();
        }

        public void Tick()
        {
            UpdatePosition();
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0031:Используйте распространение значения NULL", Justification = "<Ожидание>")]
        public void UpdatePosition()
        {
            if (source == null) return;
            Vector3 displayerTop = source.Bounds.center;
            displayerTop.y = source.Bounds.max.y;
            displayerTop += source.Offset;
            Vector3 displayerTopDirection = displayerTop - cameraTransform.position;
            var lookDot = Vector3.Dot(displayerTopDirection, cameraTransform.forward);
            if (facade.Gui != null) facade.Gui.SetActive(lookDot > 0);

            facade.transform.position = camera.WorldToScreenPoint(displayerTop);
        }
    }
}
