using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MOATT.Levels.Buildings
{
    public class BuildingRegistry
    {
        public readonly List<BuildingFacade> buildings = new();

        public event Action OnBuildingUpgraded;
        public event Action<BuildingFacade> OnBuildingAdded;

        public void Add(BuildingFacade building)
        {
            if (building.BuildingUpgrader != null) building.BuildingUpgrader.OnUpgradeComplete += InvokeOnBuildingUpgraded;
            buildings.Add(building);
            OnBuildingAdded?.Invoke(building);
        }

        public void Remove(BuildingFacade building)
        {
            if (building.BuildingUpgrader != null) building.BuildingUpgrader.OnUpgradeComplete -= InvokeOnBuildingUpgraded;
            buildings.Remove(building);
        }

        private void InvokeOnBuildingUpgraded()
        {
            OnBuildingUpgraded?.Invoke();
        }
    }
}
