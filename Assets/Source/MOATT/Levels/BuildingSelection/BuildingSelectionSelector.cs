using MOATT.InputLogic;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace MOATT.Levels.BuildingSelection
{
    using Buildings;
    using MOATT.GUILogic;
    using MOATT.Levels.BuildingPlacement;

    public class BuildingSelectionSelector : IInitializable, IDisposable
    {
        private readonly InputAssetMapSwapper mapSwapper;
        private readonly InputAsset inputAsset;
        private readonly PointerOverUIWatcher pointerOverUIWatcher;
        private readonly BuildingPlacementSelector buildingPlacementSelector;

        private BuildingFacade selectedBuilding;

        public event Action OnBuildingSelected;

        public BuildingSelectionSelector(InputAssetMapSwapper mapSwapper, InputAsset inputAsset, BuildingSelectionHoverer hoverer, PointerOverUIWatcher pointerOverUIWatcher, BuildingPlacementSelector buildingPlacementSelector)
        {
            this.mapSwapper = mapSwapper;
            this.inputAsset = inputAsset;
            this.pointerOverUIWatcher = pointerOverUIWatcher;
            this.buildingPlacementSelector = buildingPlacementSelector;
        }

        public BuildingFacade SelectedBuilding
        {
            get => selectedBuilding;
            private set
            {
                if (value == selectedBuilding) return;
                if (selectedBuilding != null) selectedBuilding.OnDestroyed -= OnSelectedDestroyed;
                selectedBuilding = value;
                if (selectedBuilding != null) selectedBuilding.OnDestroyed += OnSelectedDestroyed;
                OnBuildingSelected?.Invoke();
            }
        }

        public void SelectBuilding(BuildingFacade newBuilding)
        {
            if (pointerOverUIWatcher.IsPointerOverUI) return;
            SelectedBuilding = newBuilding;
        }

        public void Initialize()
        {
            mapSwapper.OnModeChanged += ModeChangedHandler;
            buildingPlacementSelector.OnBuildingSelected += BuildingSelectedHandler;
        }

        public void Dispose()
        {
            mapSwapper.OnModeChanged -= ModeChangedHandler;
            buildingPlacementSelector.OnBuildingSelected -= BuildingSelectedHandler;
        }

        private void ModeChangedHandler(InputActionMap map)
        {
            if (!inputAsset.Selection.enabled) SelectBuilding(null);
        }

        private void BuildingSelectedHandler(BuildingPlacementBuildingInfo info)
        {
            SelectedBuilding = null;
        }

        private void OnSelectedDestroyed()
        {
            SelectedBuilding = null;
        }
    }
}
