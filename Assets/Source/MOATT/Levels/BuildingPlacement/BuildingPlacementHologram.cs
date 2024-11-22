using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HologramDisplayers;
using Zenject;

namespace MOATT.Levels.BuildingPlacement
{
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
        }

        public void Dispose()
        {
            tileRaycaster.OnTileUnderMouseChanged -= TileUnderMouseChangedHandler;
        }

        private void TileUnderMouseChangedHandler(TileFacade newTile)
        {
            var args = selector.Building.GetHologramArgs(newTile);
            if (!args.IsDisplayed) { Hide(); return; }
            Show();
            hologramDisplayer.SetColor(args.IsAcceptable ? Color.green : Color.red);
            hologramDisplayer.transform.position = newTile.transform.position;
        }

        private void Hide()
        {
            hologramDisplayer.SetActive(false);
        }

        private void Show()
        {
            hologramDisplayer.SetActive(true);
            hologramDisplayer.SetModel(selector.Building.gameObject);
        }

        public class DisplayArgs
        {
            public bool IsDisplayed;
            public bool IsAcceptable;
        }
    }
}
