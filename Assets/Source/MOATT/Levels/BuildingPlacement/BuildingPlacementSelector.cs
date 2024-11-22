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
        private readonly BuildingFacade.Factory buildingFactory;

        public event System.Action<BuildingFacade> OnBuildingSelected;

        public BuildingPlacementSelector(InputAssetMapSwapper mapSwapper, BuildingFacade.Factory buildingFactory = null)
        {
            this.mapSwapper = mapSwapper;
            this.buildingFactory = buildingFactory;
        }

        public BuildingFacade Building { get; private set; }

        public void SelectBuilding(BuildingFacade newPrefab)
        {
            if (Building != null) Building.Destroy();
            if (newPrefab != null) Building = buildingFactory.Create(newPrefab, new(new()));
            else Building = null;

            mapSwapper.CurrentMap = Building != null ?
                mapSwapper.inputAsset.BuildingPlacement :
                mapSwapper.inputAsset.Selection;

            OnBuildingSelected?.Invoke(Building);
        }
    }
}
