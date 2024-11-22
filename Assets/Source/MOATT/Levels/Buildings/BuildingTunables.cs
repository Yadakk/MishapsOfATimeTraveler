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

        public BuildingTunables(GameObjectCreationParameters goParams)
        {
            this.goParams = goParams;
        }
    }
}
