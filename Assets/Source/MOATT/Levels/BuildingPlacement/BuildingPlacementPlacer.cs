using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace MOATT.Levels.BuildingPlacement
{
    using Buildings;
    using MOATT.InputLogic;
    using MOATT.Levels.Tiles;

    public class BuildingPlacementPlacer
    {
        private readonly BuildingPlacementSelector selector;
        private readonly BuildingFacade.Factory buildingFactory;

        public BuildingPlacementPlacer(
            BuildingPlacementSelector selector, 
            BuildingFacade.Factory buildingFactory)
        {
            this.selector = selector;
            this.buildingFactory = buildingFactory;
        }

        public void PlaceBuilding()
        {
            if (!TryPlaceBuilding()) selector.SelectBuilding(null);
        }

        private bool TryPlaceBuilding()
        {
            if (selector.BuildingPrefab == null) return false;
            var selectedTile = TileHoverListener.TileUnderMouse;
            if (selectedTile == null) return false;
            if (selectedTile.CurrentBuilding != null) return false;
            buildingFactory.Create(selector.BuildingPrefab, selectedTile.TileBuilding);
            return true;
        }
    }
}
