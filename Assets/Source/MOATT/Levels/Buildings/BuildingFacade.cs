using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace MOATT.Levels.Buildings
{
    using MOATT.Levels.Tiles;
    using System.Linq;

    public class BuildingFacade : MonoBehaviour
    {
        public BuildingSettingsInstaller SettingsInstaller { get; private set; }

        [Inject]
        public void Construct([InjectOptional] BuildingTunables tunables)
        {
            if (tunables == null) return;
            tunables.initTile.SetBuilding(this);
        }

        public void Destroy()
        {
            Destroy(gameObject);
        }

        public BuildingSettingsInstaller GetSettingsInstaller()
        {
            if (SettingsInstaller != null) return SettingsInstaller;
            SettingsInstaller = GetComponent<GameObjectContext>().
                ScriptableObjectInstallers.
                OfType<BuildingSettingsInstaller>().First();
            return SettingsInstaller;
        }

        [System.Serializable]
        public class Settings
        {
            public TileBuilding.TileType canBePlacedOn;
        }

        public class Factory : PlaceholderFactory<Object, BuildingTunables, BuildingFacade> { }
    }
}
