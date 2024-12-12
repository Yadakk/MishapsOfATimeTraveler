using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Zenject;

namespace MOATT.Levels.Buildings
{
    using Health;
    using MOATT.Levels.Billboards;
    using MOATT.Levels.Units.Damage;
    using MOATT.Levels.Units.ReloadTime;
    using Tiles;
    using Units.Range;

    public class BuildingFacade : MonoBehaviour
    {
        private Settings settings;
        private BuildingRegistry buildingRegistry;
        private UnitReloadTime reloadTime;
        private UnitDamage unitDamage;

        [System.Flags]
        public enum BuildingType
        {
            Common = 1,
            Tower = 2,
        }

        public event System.Action OnDestroyed;

        public HealthModel HealthModel { get; private set; }
        public UnitRange BuildingRange { get; private set; }
        public Outline Outline { get; private set; }

        public TileBuilding.TileType CanBePlacedOn => settings.canBePlacedOn;
        public BuildingType Type => settings.buildingType;
        public int NutsAndBoltsCost => settings.nutsAndBoltsCost;

        public BillboardSource BillboardSource { get; private set; }
        public BuildingUpgrader BuildingUpgrader { get; private set; }

        private void Start()
        {
            buildingRegistry.Add(this);
        }

        private void OnDestroy()
        {
            buildingRegistry.Remove(this);
            OnDestroyed?.Invoke();
        }

        [Inject]
        public void Construct(
            Settings settings,
            [InjectOptional] BuildingTunables tunables,
            [InjectOptional] HealthModel healthModel,
            [InjectOptional] UnitRange buildingRange,
            BuildingRegistry buildingRegistry,
            Outline outline,
            BillboardSource billboardSource,
            [InjectOptional] BuildingUpgrader buildingUpgrader,
            [InjectOptional] UnitReloadTime reloadTime,
            [InjectOptional] UnitDamage unitDamage
            )
        {
            this.settings = settings;
            this.buildingRegistry = buildingRegistry;
            this.reloadTime = reloadTime;
            this.unitDamage = unitDamage;
            Outline = outline;

            HealthModel = healthModel;
            BuildingRange = buildingRange;

            if (tunables?.initTile != null)
                tunables.initTile.SetBuilding(this);

            if (tunables?.goParams?.ParentTransform != null)
                transform.SetParent(tunables.goParams.ParentTransform);

            BillboardSource = billboardSource;
            BuildingUpgrader = buildingUpgrader;
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new();
            stringBuilder.AppendLine(settings.name);
            stringBuilder.AppendLine($"Cost: {NutsAndBoltsCost} Nuts and Bolts");
            if (HealthModel != null) stringBuilder.AppendLine($"Health: {HealthModel.MaxHealth} hp");
            if (BuildingRange != null) stringBuilder.AppendLine($"Range: {BuildingRange.RangeTiles} tiles");
            if (reloadTime != null) stringBuilder.AppendLine($"Can attack every: {reloadTime.Value} seconds");
            if (unitDamage != null) stringBuilder.AppendLine($"Damage/Heal: {unitDamage.Value}");
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
