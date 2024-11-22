using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HologramDisplayers;
using Zenject;

namespace MOATT.Levels.BuildingPlacement
{
    using Buildings;
    using Tiles;

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
            selector.OnBuildingSelected += BuildingSelectedHandler;
        }

        public void Dispose()
        {
            tileRaycaster.OnTileUnderMouseChanged -= TileUnderMouseChangedHandler;
        }

        private void TileUnderMouseChangedHandler(TileFacade newTile)
        {
            UpdateDisplayer();
        }

        private void BuildingSelectedHandler(BuildingFacade facade)
        {
            UpdateDisplayer();
        }

        private void UpdateDisplayer()
        {
            var args = selector.BuildingPrefab.GetHologramArgs(
                tileRaycaster.TileUnderMouse);

            if (!args.IsDisplayed) { Hide(); return; }
            Show();
            hologramDisplayer.SetColor(args.IsAcceptable ? Color.green : Color.red);

            hologramDisplayer.transform.position = 
                tileRaycaster.TileUnderMouse.transform.position;
        }

        private void Hide()
        {
            hologramDisplayer.SetActive(false);
        }

        private void Show()
        {
            hologramDisplayer.SetActive(true);
            hologramDisplayer.SetModel(selector.BuildingPrefab.gameObject);
        }

        public class DisplayArgs
        {
            public bool IsDisplayed;
            public bool IsAcceptable;
        }
    }
}
