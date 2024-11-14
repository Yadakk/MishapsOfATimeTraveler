using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace MOATT.Levels.BuildingPlacement
{
    using Buildings;

    public class BuildingSelector : MonoBehaviour
    {
        [SerializeField]
        private BuildingFacade buildingPrefab;

        private BuildingPlacer placer;

        [Inject]
        public void Construct(BuildingPlacer placer)
        {
            this.placer = placer;
        }

        public void Select()
        {
            placer.SelectBuilding(buildingPrefab);
        }
    }
}
