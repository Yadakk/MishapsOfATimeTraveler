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

        public BuildingFacade BuildingPrefab { get; private set; }

        public void SelectBuilding(BuildingFacade newPrefab)
        {
            BuildingPrefab = newPrefab;

            mapSwapper.CurrentMap = BuildingPrefab != null ?
                mapSwapper.inputAsset.BuildingPlacement :
                mapSwapper.inputAsset.Selection;

            OnBuildingSelected?.Invoke(BuildingPrefab);
        }
    }
}
