using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace MOATT.Levels.BuildingPlacement
{
    using Buildings;
    using MOATT.Levels.Economics;

    public class BuildingPlacementSelectorVM : MonoBehaviour
    {
        [SerializeField]
        private BuildingFacade buildingPrefab;

        private BuildingPlacementSelector selector;
        private BuildingFacade.Factory buildingFactory;
        private PlayerResources playerResources;

        private BuildingFacade buildingPrototype;

        private void Awake()
        {
            buildingPrototype = buildingFactory.Create(buildingPrefab, null);
            buildingPrototype.gameObject.SetActive(false);
        }

        [Inject]
        public void Construct(BuildingPlacementSelector selector, BuildingFacade.Factory buildingFactory, PlayerResources playerResources)
        {
            this.selector = selector;
            this.buildingFactory = buildingFactory;
            this.playerResources = playerResources;
        }

        public void Select()
        {
            bool isDifferentBuilding = selector.BuildingPrototype != buildingPrototype;
            bool isAffordable = playerResources.NutsAndBolts >= buildingPrototype.NutsAndBoltsCost;

            if (isDifferentBuilding && isAffordable)
                selector.SelectBuilding(buildingPrototype);
            else
                selector.SelectBuilding(null);
        }
    }
}
