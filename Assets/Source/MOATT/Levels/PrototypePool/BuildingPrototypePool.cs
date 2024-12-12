using MOATT.Levels.Buildings;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace MOATT.Levels.PrototypePool
{
    public class BuildingPrototypePool : MonoBehaviour
    {
        private readonly Dictionary<BuildingFacade, BuildingFacade> pool = new();
        private BuildingFacade.Factory buildingFactory;

        [Inject]
        public void Construct(BuildingFacade.Factory buildingFactory)
        {
            this.buildingFactory = buildingFactory;
        }

        public BuildingFacade GetPrototype(BuildingFacade prefab)
        {
            if (pool.TryGetValue(prefab, out var building)) return building;
            BuildingFacade instantiatedBuilding = buildingFactory.Create(
                prefab, new(null, null));
            instantiatedBuilding.transform.SetParent(transform);
            instantiatedBuilding.gameObject.SetActive(false);
            pool.Add(prefab, instantiatedBuilding);
            return instantiatedBuilding;
        }
    }
}
