using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace MOATT.Levels.BuildingPlacement
{
    using Buildings;

    public class BuildingPlacementSelectorVM : MonoBehaviour
    {
        [SerializeField]
        private BuildingFacade buildingPrefab;

        private BuildingPlacementSelector selector;

        [Inject]
        public void Construct(BuildingPlacementSelector selector)
        {
            this.selector = selector;
        }

        public void Select()
        {
            selector.SelectBuilding(buildingPrefab);
        }
    }
}
