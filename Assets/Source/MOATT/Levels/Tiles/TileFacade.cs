using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace MOATT.Levels.Tiles
{
    using Buildings;

    public class TileFacade : MonoBehaviour
    {
        public TileCell TileCell { get; private set; }
        public BuildingFacade CurrentBuilding => TileBuilding.CurrentBuilding;

        public TileBuilding TileBuilding { get; private set; }

        [Inject]
        public void Construct(TileCell tileCell, TileBuilding tileBuilding)
        {
            TileCell = tileCell;
            TileBuilding = tileBuilding;
        }

        public void SetBuilding(BuildingFacade building)
        {
            TileBuilding.SetBuilding(building);
        }
    }
}