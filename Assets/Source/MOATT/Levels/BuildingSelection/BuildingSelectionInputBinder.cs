using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace MOATT.Levels.BuildingSelection
{
    public class BuildingSelectionInputBinder : IInitializable, IDisposable
    {
        private readonly InputAsset inputAsset;
        private readonly BuildingSelectionSelector buildingSelectionSelector;
        private readonly BuildingSelectionHoverer hoverer;

        public BuildingSelectionInputBinder(InputAsset inputAsset, BuildingSelectionSelector buildingSelectionSelector, BuildingSelectionHoverer hoverer)
        {
            this.inputAsset = inputAsset;
            this.buildingSelectionSelector = buildingSelectionSelector;
            this.hoverer = hoverer;
        }

        public void Initialize()
        {
            inputAsset.Selection.Select.performed += SelectHandler;
        }

        public void Dispose()
        {
            inputAsset.Selection.Select.performed -= SelectHandler;
        }

        private void SelectHandler(InputAction.CallbackContext context)
        {
            buildingSelectionSelector.SelectBuilding(hoverer.HoveredBuilding);
        }
    }
}
