using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace MOATT.Levels.BuildingPlacement
{
    using Buildings;
    using Tiles;
    using GUILogic;
    using MOATT.Levels.Economics;

    public class BuildingPlacementPlacer
    {
        private readonly BuildingPlacementSelector selector;
        private readonly BuildingFacade.Factory buildingFactory;
        private readonly TileRaycaster tileRaycaster;
        private readonly PointerOverUIWatcher pointerOverUIWatcher;
        private readonly PlayerResources playerResources;

        public System.Action OnBuildingPlaced;

        public BuildingPlacementPlacer(
            BuildingPlacementSelector selector,
            BuildingFacade.Factory buildingFactory,
            TileRaycaster tileRaycaster,
            PointerOverUIWatcher pointerOverUIWatcher,
            PlayerResources playerResources)
        {
            this.selector = selector;
            this.buildingFactory = buildingFactory;
            this.tileRaycaster = tileRaycaster;
            this.pointerOverUIWatcher = pointerOverUIWatcher;
            this.playerResources = playerResources;
        }

        public void PlaceBuilding()
        {
            if (pointerOverUIWatcher.IsPointerOverUI) return;
            if (TryPlaceBuilding()) OnBuildingPlaced?.Invoke();
        }

        private bool TryPlaceBuilding()
        {
            if (pointerOverUIWatcher.IsPointerOverUI) return false;
            if (!selector.BuildingInfo.IsCharged) return false;
            if (playerResources.NutsAndBolts < selector.BuildingInfo.prototype.NutsAndBoltsCost) return false;
            var selectedTile = tileRaycaster.TileUnderMouse;
            if (!selector.BuildingInfo.prototype.CanBePlacedOn(selectedTile)) return false;
            var building = buildingFactory.Create(selector.BuildingInfo.prototype, new(new(), selectedTile));
            building.gameObject.SetActive(true);
            playerResources.NutsAndBolts -= selector.BuildingInfo.prototype.NutsAndBoltsCost;
            selector.BuildingInfo.IsCharged = false;
            return true;
        }
    }
}
