using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace MOATT.Levels.Tiles
{
    using Buildings;

    public class TileBuilding
    {
        public TileBuilding([InjectOptional] BuildingFacade building)
        {
            CurrentBuilding = building;
        }

        public BuildingFacade CurrentBuilding { get; private set; }
    }
}
