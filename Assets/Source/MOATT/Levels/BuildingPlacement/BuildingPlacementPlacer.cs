﻿using System.Collections;
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
            if (!TryPlaceBuilding()) selector.SelectBuilding(null);
        }

        private bool TryPlaceBuilding()
        {
            if (pointerOverUIWatcher.IsPointerOverUI) return false;
            var selectedTile = tileRaycaster.TileUnderMouse;
            if (!selector.Building.CanBePlacedOn(selectedTile)) return false;
            selector.Building.SetTile(selectedTile);
            return true;
        }
    }
}
