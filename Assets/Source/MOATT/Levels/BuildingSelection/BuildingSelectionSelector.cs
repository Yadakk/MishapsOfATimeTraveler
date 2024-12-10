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

    public class BuildingSelectionSelector : IInitializable, IDisposable
    {
        private readonly InputAssetMapSwapper mapSwapper;
        private readonly InputAsset inputAsset;

        private BuildingFacade selectedBuilding;

        public event Action OnBuildingSelected;

        public BuildingSelectionSelector(InputAssetMapSwapper mapSwapper, InputAsset inputAsset, BuildingSelectionHoverer hoverer)
        {
            this.mapSwapper = mapSwapper;
            this.inputAsset = inputAsset;
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
