using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace MOATT.Levels.Tiles
{
    using Buildings;

    public class TileFacade : MonoBehaviour
    {
        private TileBuilding tileBuilding;

        public TileCell TileCell { get; private set; }
        public BuildingFacade CurrentBuilding => tileBuilding.CurrentBuilding;

        [Inject]
        public void Construct(TileCell tileCell, TileBuilding tileBuilding)
        {
            TileCell = tileCell;
            this.tileBuilding = tileBuilding;
        }

        public void SetBuilding(BuildingFacade building)
        {
            tileBuilding.SetBuilding(building);
        }
    }
}