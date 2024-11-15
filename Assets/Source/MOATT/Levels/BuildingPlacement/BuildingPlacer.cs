using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace MOATT.Levels.BuildingPlacement
{
    using Buildings;
    using MOATT.InputLogic;
    using MOATT.Levels.Tiles;

    public class BuildingPlacer
    {
        private readonly InteractionModeSwitcher modeSwitcher;
        private readonly BuildingFacade.Factory buildingFactory;

        private BuildingFacade pickedBuilding;

        public BuildingPlacer(InteractionModeSwitcher modeSwitcher = null, BuildingFacade.Factory buildingFactory = null)
        {
            this.modeSwitcher = modeSwitcher;
            this.buildingFactory = buildingFactory;
        }

        public BuildingFacade PickedBuilding
        {
            get => pickedBuilding;
            set
            {
                pickedBuilding = value;
                modeSwitcher.CurrentMap = pickedBuilding != null ?
                    modeSwitcher.inputAsset.BuildingPlacement :
                    modeSwitcher.inputAsset.Selection;
            }
        }

        public void SelectBuilding(BuildingFacade buildingPrefab)
        {
            PickedBuilding = buildingPrefab;
        }

        public void PlaceBuilding()
        {
            if (!TryPlaceBuilding()) PickedBuilding = null;
        }

        private bool TryPlaceBuilding()
        {
            if (PickedBuilding == null) return false;
            var selectedTile = TileHoverListener.TileUnderMouse;
            if (selectedTile == null) return false;
            if (selectedTile.CurrentBuilding != null) return false;
            selectedTile.SetBuilding(buildingFactory.Create(PickedBuilding));
            return true;
        }
    }
}
