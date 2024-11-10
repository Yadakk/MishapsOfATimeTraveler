using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace MOATT.Levels.Tiles
{
    using Buildings;

    public class TileBuilding
    {
        public BuildingFacade CurrentBuilding { get; private set; }

        [Inject]
        public void Construct([InjectOptional] BuildingFacade building)
        {
            CurrentBuilding = building;
        }
    }
}
