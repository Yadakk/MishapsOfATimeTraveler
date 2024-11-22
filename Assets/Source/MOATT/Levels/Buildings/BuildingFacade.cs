using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace MOATT.Levels.Buildings
{
    using MOATT.Levels.Tiles;

    public class BuildingFacade : MonoBehaviour
    {
        [System.NonSerialized]
        public TileFacade CurrentTile;

        private Settings settings;

        public TileBuilding.TileType CanBePlacedOn => settings.canBePlacedOn;

        private void Awake()
        {
            gameObject.SetActive(false);
        }

        [Inject]
        public void Construct(Settings settings, [InjectOptional] BuildingTunables tunables)
        {
            this.settings = settings;

            if (tunables == null) return;
        }

        public void Destroy()
        {
            Destroy(gameObject);
        }

        public void SetTile(TileFacade newTile)
        {
            gameObject.SetActive(true);

            if (CurrentTile != null) CurrentTile.SetBuilding(null);
            CurrentTile = newTile;
            CurrentTile.SetBuilding(this);
        }

        [System.Serializable]
        public class Settings
        {
            public TileBuilding.TileType canBePlacedOn;
        }

        public class Factory : PlaceholderFactory<Object, BuildingTunables, BuildingFacade> { }
    }
}
