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
        private readonly Settings settings;

        [System.Flags]
        public enum TileType
        {
            Nothing = 0,
            Unplaceable = 1,
            Slot = 2,
            Road = 4,
        }

        public TileBuilding([InjectOptional] BuildingFacade building, TileFacade facade = null, Settings settings = null)
        {
            CurrentBuilding = building;
            this.facade = facade;
            this.settings = settings;
        }

        public TileType Type => settings.type;

        public void SetBuilding(BuildingFacade building)
        {
            building.transform.SetParent(facade.transform, false);
            CurrentBuilding = building;
        }

        public BuildingFacade CurrentBuilding { get; private set; }

        [System.Serializable]
        public class Settings
        {
            public TileType type;
        }
    }
}
