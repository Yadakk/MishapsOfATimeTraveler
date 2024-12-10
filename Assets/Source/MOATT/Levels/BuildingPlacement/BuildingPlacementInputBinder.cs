using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace MOATT.Levels.BuildingPlacement
{
    public class BuildingPlacementInputBinder : IInitializable, System.IDisposable
    {
        private readonly InputAsset inputAsset;
        private readonly BuildingPlacementPlacer buildingPlacer;
        private readonly BuildingPlacementSelector selector;

        public BuildingPlacementInputBinder(InputAsset inputAsset, BuildingPlacementPlacer buildingPlacer, BuildingPlacementSelector selector)
        {
            this.inputAsset = inputAsset;
            this.buildingPlacer = buildingPlacer;
            this.selector = selector;
        }

        public void Initialize()
        {
            inputAsset.BuildingPlacement.Place.performed += PlaceHandler;
            inputAsset.BuildingPlacement.Deselect.performed += DeselectHandler;
        }

        public void Dispose()
        {
            inputAsset.BuildingPlacement.Place.performed -= PlaceHandler;
            inputAsset.BuildingPlacement.Deselect.performed -= DeselectHandler;
        }

        private void PlaceHandler(InputAction.CallbackContext context)
        {
            buildingPlacer.PlaceBuilding();
        }

        private void DeselectHandler(InputAction.CallbackContext context)
        {
            selector.SelectBuilding(null);
        }
    }
}
