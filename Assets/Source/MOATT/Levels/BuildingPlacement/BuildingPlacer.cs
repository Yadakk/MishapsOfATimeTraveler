using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using HologramDisplayers;

namespace MOATT.Levels.BuildingPlacement
{
    using Buildings;
    using MOATT.InputLogic;
    using MOATT.Levels.Tiles;
    using ModestTree;
    using UnityEngine.InputSystem;

    public class BuildingPlacer : IInitializable, System.IDisposable
    {
        private readonly InteractionModeSwitcher modeSwitcher;
        private readonly BuildingFacade.Factory buildingFactory;
        private readonly HologramDisplayer hologramDisplayer;

        private BuildingFacade pickedBuilding;

        public BuildingPlacer(InteractionModeSwitcher modeSwitcher = null, BuildingFacade.Factory buildingFactory = null, HologramDisplayer hologramDisplayer = null)
        {
            this.modeSwitcher = modeSwitcher;
            this.buildingFactory = buildingFactory;
            this.hologramDisplayer = hologramDisplayer;
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

        public void Initialize()
        {
            TileHoverListener.OnTileUnderMouseChanged += TileUnderMouseChangedHandler;
            modeSwitcher.OnModeChanged += ModeChangedHandler;
        }

        public void Dispose()
        {
            TileHoverListener.OnTileUnderMouseChanged -= TileUnderMouseChangedHandler;
            modeSwitcher.OnModeChanged -= ModeChangedHandler;
        }

        private void TileUnderMouseChangedHandler()
        {
            if (TileHoverListener.TileUnderMouse == null) return;
            hologramDisplayer.transform.position = TileHoverListener.TileUnderMouse.transform.position;
        }

        private void ModeChangedHandler(InputActionMap newMap)
        {
            if (newMap == null) return;
            hologramDisplayer.SetActive(newMap.name == nameof(modeSwitcher.inputAsset.BuildingPlacement));
        }

        public void SelectBuilding(BuildingFacade buildingPrefab)
        {
            PickedBuilding = buildingPrefab;
            hologramDisplayer.SetModel(buildingPrefab.gameObject);
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
