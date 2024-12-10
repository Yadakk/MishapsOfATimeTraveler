using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace MOATT.Levels.BuildingSelection
{
    using Tiles;
    using Buildings;

    public class BuildingSelectionHoverer : IInitializable, IDisposable
    {
        private readonly TileRaycaster tileRaycaster;

        private BuildingFacade hoveredBuilding;

        public event Action OnBuildingHovered;

        public BuildingSelectionHoverer(TileRaycaster tileRaycaster)
        {
            this.tileRaycaster = tileRaycaster;
        }

        public BuildingFacade HoveredBuilding
        {
            get => hoveredBuilding;
            private set
            {
                if (value == hoveredBuilding) return;
                hoveredBuilding = value;
                OnBuildingHovered?.Invoke();
            }
        }

        public void Initialize()
        {
            tileRaycaster.OnTileUnderMouseChanged += TileUnderMouseChangedHandler;
        }

        public void Dispose()
        {
            tileRaycaster.OnTileUnderMouseChanged -= TileUnderMouseChangedHandler;
        }

        private void TileUnderMouseChangedHandler(TileFacade tile)
        {
            if (tile == null) HoveredBuilding = null;
            else HoveredBuilding = tile.CurrentBuilding;
        }
    }
}
