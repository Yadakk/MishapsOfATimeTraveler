using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MOATT.Levels.BuildingPlacement
{
    using Buildings;
    using InputLogic;

    public class BuildingPlacementSelector
    {
        private readonly InputAssetMapSwapper mapSwapper;

        public event System.Action<BuildingFacade> OnBuildingSelected;

        public BuildingPlacementSelector(InputAssetMapSwapper mapSwapper)
        {
            this.mapSwapper = mapSwapper;
        }

        public BuildingFacade BuildingPrototype { get; private set; }

        public void SelectBuilding(BuildingFacade newPrototype)
        {
            BuildingPrototype = newPrototype;

            mapSwapper.CurrentMap = BuildingPrototype != null ?
                mapSwapper.inputAsset.BuildingPlacement :
                mapSwapper.inputAsset.Selection;

            OnBuildingSelected?.Invoke(BuildingPrototype);
        }
    }
}
