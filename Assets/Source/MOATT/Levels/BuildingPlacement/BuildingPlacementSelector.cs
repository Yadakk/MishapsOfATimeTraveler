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

        public event System.Action<BuildingPlacementBuildingInfo> OnBuildingSelected;

        public BuildingPlacementSelector(InputAssetMapSwapper mapSwapper)
        {
            this.mapSwapper = mapSwapper;
        }

        public BuildingPlacementBuildingInfo BuildingInfo { get; private set; }

        public void SelectBuilding(BuildingPlacementBuildingInfo newInfo)
        {
            BuildingInfo = newInfo;

            mapSwapper.CurrentMap = BuildingInfo != null ?
                mapSwapper.inputAsset.BuildingPlacement :
                mapSwapper.inputAsset.Selection;

            OnBuildingSelected?.Invoke(BuildingInfo);
        }
    }
}
