using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace MOATT.Levels.BuildingPlacement
{
    using Buildings;
    using Tiles;

    public class BuildingPlacementPlacer
    {
        private readonly BuildingPlacementSelector selector;
        private readonly BuildingFacade.Factory buildingFactory;
        private readonly TileRaycaster tileRaycaster;

        public BuildingPlacementPlacer(
            BuildingPlacementSelector selector,
            BuildingFacade.Factory buildingFactory,
            TileRaycaster tileRaycaster = null)
        {
            this.selector = selector;
            this.buildingFactory = buildingFactory;
            this.tileRaycaster = tileRaycaster;
        }

        public void PlaceBuilding()
        {
            if (!TryPlaceBuilding()) selector.SelectBuilding(null);
        }

        private bool TryPlaceBuilding()
        {
            if (selector.BuildingPrefab == null) return false;
            var selectedTile = tileRaycaster.TileUnderMouse;
            if (selectedTile == null) return false;
            if (selectedTile.CurrentBuilding != null) return false;
            buildingFactory.Create(selector.BuildingPrefab, new(selectedTile));
            return true;
        }
    }
}
