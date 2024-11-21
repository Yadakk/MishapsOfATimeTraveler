using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;
using GameObjectGetters;

namespace MOATT.Levels.Tiles
{
    using Layers;

    public class TileRaycaster : ITickable
    {
        private readonly Camera camera;
        private readonly LayerMasks layerMasks;
        private readonly TileFacade[] tiles;

        private GameObject lastGO;

        public event System.Action<TileFacade> OnTileUnderMouseChanged;

        public TileFacade TileUnderMouse { get; private set; }

        public TileRaycaster(Camera camera, LayerMasks layerMasks, TileFacade[] tiles = null)
        {
            this.camera = camera;
            this.layerMasks = layerMasks;
            this.tiles = tiles;
        }

        public void Tick()
        {
            TileFacade newTile = RaycastTile();
            if (newTile == TileUnderMouse) return;
            TileUnderMouse = newTile;
            OnTileUnderMouseChanged?.Invoke(TileUnderMouse);
        }

        private TileFacade RaycastTile()
        {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            if (!Physics.Raycast(
                ray, out RaycastHit hitInfo, Mathf.Infinity, layerMasks.tileMask)) return null;
            var go = hitInfo.collider.gameObject;
            if (go == lastGO) return TileUnderMouse;
            lastGO = go;
            return tiles.FirstOrDefault(tile => go.HasParent(tile.gameObject));
        }
    }
}
