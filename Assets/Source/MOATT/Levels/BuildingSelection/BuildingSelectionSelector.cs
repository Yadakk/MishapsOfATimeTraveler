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

    public class BuildingSelectionSelector : IInitializable, IDisposable
    {
        private readonly InputAssetMapSwapper mapSwapper;
        private readonly InputAsset inputAsset;
        private readonly PointerOverUIWatcher pointerOverUIWatcher;

        private BuildingFacade selectedBuilding;

        public event Action OnBuildingSelected;

        public BuildingSelectionSelector(InputAssetMapSwapper mapSwapper, InputAsset inputAsset, BuildingSelectionHoverer hoverer, PointerOverUIWatcher pointerOverUIWatcher)
        {
            this.mapSwapper = mapSwapper;
            this.inputAsset = inputAsset;
            this.pointerOverUIWatcher = pointerOverUIWatcher;
        }

        public BuildingFacade SelectedBuilding
        {
            get => selectedBuilding;
            private set
            {
                if (value == selectedBuilding) return;
                selectedBuilding = value;
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
        }

        public void Dispose()
        {
            mapSwapper.OnModeChanged -= ModeChangedHandler;
        }

        private void ModeChangedHandler(InputActionMap map)
        {
            if (!inputAsset.Selection.enabled) SelectBuilding(null);
        }
    }
}
