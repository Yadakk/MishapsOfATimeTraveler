using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace MOATT.Levels.BuildingPlacement
{
    using Buildings;
    using Tiles;
    using GUILogic;

    public class BuildingPlacementPlacer
    {
        private readonly BuildingPlacementSelector selector;
        private readonly BuildingFacade.Factory buildingFactory;
        private readonly TileRaycaster tileRaycaster;
        private readonly PointerOverUIWatcher pointerOverUIWatcher;

        public System.Action OnBuildingPlaced;

        public BuildingPlacementPlacer(
            BuildingPlacementSelector selector,
            BuildingFacade.Factory buildingFactory,
            TileRaycaster tileRaycaster,
            PointerOverUIWatcher pointerOverUIWatcher)
        {
            this.selector = selector;
            this.buildingFactory = buildingFactory;
            this.tileRaycaster = tileRaycaster;
            this.pointerOverUIWatcher = pointerOverUIWatcher;
        }

        public void PlaceBuilding()
        {
            if (pointerOverUIWatcher.IsPointerOverUI) return;
            if (TryPlaceBuilding()) OnBuildingPlaced?.Invoke();
        }

        private bool TryPlaceBuilding()
        {
            if (pointerOverUIWatcher.IsPointerOverUI) return false;
            var selectedTile = tileRaycaster.TileUnderMouse;
            if (!selector.BuildingPrototype.CanBePlacedOn(selectedTile)) return false;
            var building = buildingFactory.Create(selector.BuildingPrototype, new(new(), selectedTile));
            building.gameObject.SetActive(true);
            return true;
        }
    }
}
