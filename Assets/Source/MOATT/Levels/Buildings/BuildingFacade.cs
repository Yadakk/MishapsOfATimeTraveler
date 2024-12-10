using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Zenject;

namespace MOATT.Levels.Buildings
{
    using Health;
    using System.Text.RegularExpressions;
    using Tiles;
    using Units.Range;

    public class BuildingFacade : MonoBehaviour
    {
        private Settings settings;
        private BuildingRegistry buildingRegistry;

        [System.Flags]
        public enum BuildingType
        {
            Common = 1,
            Tower = 2,
        }

        public HealthModel HealthModel { get; private set; }
        public UnitRange BuildingRange { get; private set; }
        public Outline Outline { get; private set; }

        public TileBuilding.TileType CanBePlacedOn => settings.canBePlacedOn;
        public BuildingType Type => settings.buildingType;
        public int NutsAndBoltsCost => settings.nutsAndBoltsCost;

        private void Start()
        {
            buildingRegistry.Add(this);
        }

        private void OnDestroy()
        {
            buildingRegistry.Remove(this);
        }

        [Inject]
        public void Construct(
            Settings settings,
            [InjectOptional] BuildingTunables tunables,
            [InjectOptional] HealthModel healthModel,
            [InjectOptional] UnitRange buildingRange,
            BuildingRegistry buildingRegistry,
            Outline outline
            )
        {
            this.settings = settings;
            this.buildingRegistry = buildingRegistry;
            Outline = outline;

            HealthModel = healthModel;
            BuildingRange = buildingRange;

            tunables?.initTile.SetBuilding(this);
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new();
            stringBuilder.AppendLine(settings.name);
            stringBuilder.AppendLine($"Cost: {NutsAndBoltsCost} Nuts and Bolts");
            if (HealthModel != null) stringBuilder.AppendLine($"Health: {HealthModel.MaxHealth} hp");
            if (BuildingRange != null) stringBuilder.AppendLine($"Range: {BuildingRange.RangeTiles} tiles");
            return stringBuilder.ToString();
        }

        public void Destroy()
        {
            Destroy(gameObject);
        }

        public void Damage(float amount)
        {
            HealthModel.CurrentHealth -= amount;
        }

        public void Heal(float amount)
        {
            HealthModel.CurrentHealth += amount;
        }

        [System.Serializable]
        public class Settings
        {
            public string name;
            public TileBuilding.TileType canBePlacedOn;
            public BuildingType buildingType;
            public int nutsAndBoltsCost = 100;
        }

        public class Factory : PlaceholderFactory<Object, BuildingTunables, BuildingFacade> { }
    }
}
