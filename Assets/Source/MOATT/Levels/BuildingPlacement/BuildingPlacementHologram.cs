using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HologramDisplayers;
using Zenject;

namespace MOATT.Levels.BuildingPlacement
{
    using Tiles;
    using Buildings;

    public class BuildingPlacementHologram : IInitializable, System.IDisposable
    {
        private readonly HologramDisplayer hologramDisplayer;
        private readonly BuildingPlacementSelector selector;

        public BuildingPlacementHologram(HologramDisplayer hologramDisplayer, BuildingPlacementSelector selector = null)
        {
            this.hologramDisplayer = hologramDisplayer;
            this.selector = selector;
        }

        public void Initialize()
        {
            TileHoverListener.OnTileUnderMouseChanged += TileUnderMouseChangedHandler;
            selector.OnBuildingSelected += ModeChangedHandler;
        }

        public void Dispose()
        {
            TileHoverListener.OnTileUnderMouseChanged -= TileUnderMouseChangedHandler;
            selector.OnBuildingSelected -= ModeChangedHandler;
        }

        private void TileUnderMouseChangedHandler()
        {
            if (TileHoverListener.TileUnderMouse == null) return;
            hologramDisplayer.transform.position = TileHoverListener.TileUnderMouse.transform.position;
        }

        private void ModeChangedHandler(BuildingFacade buildingPrefab)
        {
            if (buildingPrefab == null) Hide();
            else Show(buildingPrefab);
        }

        private void Hide()
        {
            hologramDisplayer.SetActive(false);
        }

        private void Show(BuildingFacade buildingPrefab)
        {
            hologramDisplayer.SetActive(true);
            hologramDisplayer.SetModel(buildingPrefab.gameObject);
        }
    }
}
