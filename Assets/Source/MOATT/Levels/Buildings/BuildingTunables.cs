using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MOATT.Levels.Buildings
{
    using Tiles;
    using Zenject;

    public class BuildingTunables
    {
        public readonly GameObjectCreationParameters goParams;
        public readonly TileFacade initTile;

        public BuildingTunables(GameObjectCreationParameters goParams, TileFacade initTile)
        {
            this.goParams = goParams;
            this.initTile = initTile;
        }
    }
}
