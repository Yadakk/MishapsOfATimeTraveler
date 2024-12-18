using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HologramDisplayers;
using Zenject;

namespace MOATT.Levels.BuildingPlacement
{
    using Buildings;
    using System;
    using Tiles;

    public class BuildingPlacementHologram : IInitializable, IDisposable
    {
        private readonly HologramDisplayer hologramDisplayer;
        private readonly BuildingPlacementSelector selector;
        private readonly TileRaycaster tileRaycaster;
        private readonly BuildingPlacementPlacer buildingPlacementPlacer;
        private readonly BuildingPlacementRange buildingPlacementRange;

        #region ctor
        public BuildingPlacementHologram(
            HologramDisplayer hologramDisplayer,
            BuildingPlacementSelector selector,
            TileRaycaster tileRaycaster,
            BuildingPlacementPlacer buildingPlacementPlacer,
            BuildingPlacementRange buildingPlacementRange = null)
        {
            this.hologramDisplayer = hologramDisplayer;
            this.selector = selector;
            this.tileRaycaster = tileRaycaster;
            this.buildingPlacementPlacer = buildingPlacementPlacer;
            this.buildingPlacementRange = buildingPlacementRange;
        }
        #endregion

        public void Initialize()
        {
            tileRaycaster.OnTileUnderMouseChanged += TileUnderMouseChangedHandler;
            selector.OnBuildingSelected += BuildingSelectedHandler;
            buildingPlacementPlacer.OnBuildingPlaced += BuildingPlacedHandler;
        }

        public void Dispose()
        {
            tileRaycaster.OnTileUnderMouseChanged -= TileUnderMouseChangedHandler;
            selector.OnBuildingSelected -= BuildingSelectedHandler;
            buildingPlacementPlacer.OnBuildingPlaced -= BuildingPlacedHandler;
        }

        private void TileUnderMouseChangedHandler(TileFacade newTile)
        {
            if (selector.BuildingInfo == null) return;
            UpdateDisplayer();
        }

        private void BuildingSelectedHandler(BuildingPlacementBuildingInfo info)
        {
            UpdateDisplayer();
        }

        private void BuildingPlacedHandler()
        {
            UpdateDisplayer();
        }

        private void UpdateDisplayer()
        {
            var prototype = selector.BuildingInfo?.prototype;
            var args = prototype.GetHologramArgs(
                tileRaycaster.TileUnderMouse);

            if (!args.IsDisplayed) { Hide(); return; }
            Show();
            hologramDisplayer.SetColor(args.IsAcceptable ? Color.green : Color.red);

            var tileUnderMousePos = tileRaycaster.TileUnderMouse.transform.position;
            hologramDisplayer.transform.position = tileUnderMousePos;
            buildingPlacementRange.DisplayRange(selector.BuildingInfo.prototype, tileUnderMousePos);
        }

        private void Hide()
        {
            hologramDisplayer.SetActive(false);
            buildingPlacementRange.Hologram.SetActive(false);
        }

        private void Show()
        {
            hologramDisplayer.SetActive(true);
            buildingPlacementRange.Hologram.SetActive(true);
            hologramDisplayer.SetModel(selector.BuildingInfo.prototype.gameObject);
        }

        public class DisplayArgs
        {
            public bool IsDisplayed;
            public bool IsAcceptable;
        }
    }
}
