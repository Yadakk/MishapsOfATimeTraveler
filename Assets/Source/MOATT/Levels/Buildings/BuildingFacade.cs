using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace MOATT.Levels.Buildings
{
    using Health;
    using Tiles;
    using System.Linq;

    public class BuildingFacade : MonoBehaviour
    {
        private HealthModel healthModel;

        public BuildingSOInstaller SettingsInstaller { get; private set; }

        public bool HasHealth { get; private set; }

        [Inject]
        public void Construct(
            [InjectOptional] BuildingTunables tunables,
            [InjectOptional] HealthModel healthModel)
        {
            if (healthModel != null) SetupHealthModel(healthModel);
            tunables?.initTile.SetBuilding(this);
        }

        public void Destroy()
        {
            Destroy(gameObject);
        }

        public void Damage(float amount)
        {
            healthModel.CurrentHealth -= amount;
        }

        private void SetupHealthModel(HealthModel healthModel)
        {
            this.healthModel = healthModel;
            HasHealth = true;
        }

        public BuildingSOInstaller GetSettingsInstaller()
        {
            if (SettingsInstaller != null) return SettingsInstaller;
            SettingsInstaller = GetComponent<GameObjectContext>().
                ScriptableObjectInstallers.
                OfType<BuildingSOInstaller>().First();
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
