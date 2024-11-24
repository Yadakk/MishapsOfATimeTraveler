using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;
using Cannedenuum.ZenjectUtils.MonoInterfaces;

namespace MOATT.Levels.Buildings
{
    using Health;
    using Tiles;
    using UnitRange;

    public class BuildingFacade : MonoBehaviour
    {
        public HealthModel HealthModel { get; private set; }
        public UnitRange BuildingRange { get; private set; }

        public TileBuilding.TileType CanBePlacedOn => settings.canBePlacedOn;

        private Settings settings;

        [Inject]
        public void Construct(
            Settings settings,
            [InjectOptional] BuildingTunables tunables,
            [InjectOptional] HealthModel healthModel,
            [InjectOptional] UnitRange buildingRange
            )
        {
            this.settings = settings;

            HealthModel = healthModel;
            BuildingRange = buildingRange;

            tunables?.initTile.SetBuilding(this);
        }

        public void Destroy()
        {
            Destroy(gameObject);
        }

        public void Damage(float amount)
        {
            HealthModel.CurrentHealth -= amount;
        }

        [System.Serializable]
        public class Settings
        {
            public TileBuilding.TileType canBePlacedOn;
        }

        public class Factory : PlaceholderFactory<Object, BuildingTunables, BuildingFacade> { }
    }
}
