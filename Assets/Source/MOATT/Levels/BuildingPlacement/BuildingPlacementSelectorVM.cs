using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace MOATT.Levels.BuildingPlacement
{
    using Buildings;

    public class BuildingPlacementSelectorVM : MonoBehaviour
    {
        [SerializeField]
        private BuildingFacade buildingPrefab;

        private BuildingPlacementSelector selector;
        private BuildingFacade.Factory buildingFactory;

        private BuildingFacade buildingPrototype;

        private void Awake()
        {
            buildingPrototype = buildingFactory.Create(buildingPrefab, null);
            buildingPrototype.gameObject.SetActive(false);
        }

        [Inject]
        public void Construct(BuildingPlacementSelector selector, BuildingFacade.Factory buildingFactory)
        {
            this.selector = selector;
            this.buildingFactory = buildingFactory;
        }

        public void Select()
        {
            if (selector.BuildingPrototype != buildingPrototype)
                selector.SelectBuilding(buildingPrototype);
            else
                selector.SelectBuilding(null);
        }
    }
}
