using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MOATT.Levels.Buildings
{
    public class BuildingRegistry
    {
        public readonly List<BuildingFacade> buildings = new();

        public void Add(BuildingFacade building)
        {
            buildings.Add(building);
        }

        public void Remove(BuildingFacade building)
        {
            buildings.Remove(building);
        }
    }
}
