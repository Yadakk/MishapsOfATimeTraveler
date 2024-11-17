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

        public BuildingPlacementInputBinder(InputAsset inputAsset, BuildingPlacementPlacer buildingPlacer = null)
        {
            this.inputAsset = inputAsset;
            this.buildingPlacer = buildingPlacer;
        }

        public void Initialize()
        {
            inputAsset.BuildingPlacement.Place.performed += PlaceHandler;
        }

        public void Dispose()
        {
            inputAsset.BuildingPlacement.Place.performed -= PlaceHandler;
        }

        private void PlaceHandler(InputAction.CallbackContext context)
        {
            buildingPlacer.PlaceBuilding();
        }
    }
}
