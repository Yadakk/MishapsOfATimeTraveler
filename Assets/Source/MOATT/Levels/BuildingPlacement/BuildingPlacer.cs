using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace MOATT.Levels.BuildingPlacement
{
    using Buildings;
    using MOATT.Levels.Tiles;

    public class BuildingPlacer
    {
        private readonly TileSelector tileSelector;

        private BuildingFacade pickedBuilding;

        public BuildingPlacer(TileSelector tileSelector)
        {
            this.tileSelector = tileSelector;
        }

        public void SelectBuilding(BuildingFacade buildingPrefab)
        {
            pickedBuilding = buildingPrefab;
        }

        public void PlaceBuilding()
        {
            if (!TryPlaceBuilding()) pickedBuilding = null;
        }

        private bool TryPlaceBuilding()
        {
            if (pickedBuilding == null) return false;
            var selectedTile = tileSelector.TileUnderMouse;
            if (selectedTile == null) return false;
            if (selectedTile.CurrentBuilding != null) return false;
            selectedTile.SetBuilding(pickedBuilding);
            return true;
        }
    }
}
