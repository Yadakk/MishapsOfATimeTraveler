using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace MOATT.Levels.Tiles
{
    using Buildings;

    public class TileBuilding
    {
        private readonly TileFacade facade;

        public TileBuilding([InjectOptional] BuildingFacade building, TileFacade facade = null)
        {
            CurrentBuilding = building;
            this.facade = facade;
        }

        public void SetBuilding(BuildingFacade building)
        {
            building.transform.SetParent(facade.transform);
            CurrentBuilding = building;
        }

        public BuildingFacade CurrentBuilding { get; private set; }
    }
}
