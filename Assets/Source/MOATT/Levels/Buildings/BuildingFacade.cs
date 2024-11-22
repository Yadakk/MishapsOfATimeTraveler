using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace MOATT.Levels.Buildings
{
    using MOATT.Levels.Tiles;

    public class BuildingFacade : MonoBehaviour
    {
        private Settings settings;

        public TileBuilding.TileType CanBePlacedOn => settings.canBePlacedOn;

        [Inject]
        public void Construct(Settings settings, [InjectOptional] BuildingTunables tunables)
        {
            this.settings = settings;

            if (tunables == null) return;
            tunables.initTile.SetBuilding(this);
        }

        public void Destroy()
        {
            Destroy(gameObject);
        }

        [System.Serializable]
        public class Settings
        {
            public TileBuilding.TileType canBePlacedOn;
        }

        public class Factory : PlaceholderFactory<Object, BuildingTunables, BuildingFacade> { }
    }
}
