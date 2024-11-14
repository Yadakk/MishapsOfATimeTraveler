using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace MOATT.Levels.Tiles
{
    public class TileSelector : ITickable
    {
        private readonly Camera camera;

        public TileFacade TileUnderMouse { get; private set; }

        public TileSelector(Camera camera)
        {
            this.camera = camera;
        }

        public void Tick()
        {
            TileUnderMouse = TryRaycastTile();
        }

        private TileFacade TryRaycastTile()
        {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            if (!Physics.Raycast(ray, out var hitInfo)) return null;
            if (!hitInfo.collider.gameObject.TryGetComponent<TileFacade>(out var tile)) return null;
            return tile;
        }
    }
}
