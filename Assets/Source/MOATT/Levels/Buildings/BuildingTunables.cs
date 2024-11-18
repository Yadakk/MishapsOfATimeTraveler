using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MOATT.Levels.Buildings
{
    using Tiles;

    public class BuildingTunables
    {
        public readonly TileFacade initTile;

        public BuildingTunables(TileFacade initTile)
        {
            this.initTile = initTile;
        }
    }
}
