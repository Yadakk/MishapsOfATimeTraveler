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
        private readonly TileRaycaster tileRaycaster;

        public BuildingPlacementHologram(
            HologramDisplayer hologramDisplayer,
            BuildingPlacementSelector selector,
            TileRaycaster tileRaycaster)
        {
            this.hologramDisplayer = hologramDisplayer;
            this.selector = selector;
            this.tileRaycaster = tileRaycaster;
        }

        public void Initialize()
        {
            tileRaycaster.OnTileUnderMouseChanged += TileUnderMouseChangedHandler;
            selector.OnBuildingSelected += ModeChangedHandler;
        }

        public void Dispose()
        {
            tileRaycaster.OnTileUnderMouseChanged -= TileUnderMouseChangedHandler;
            selector.OnBuildingSelected -= ModeChangedHandler;
        }

        private void TileUnderMouseChangedHandler(TileFacade newTile)
        {
            if (newTile == null) return;
            hologramDisplayer.transform.position = newTile.transform.position;
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
