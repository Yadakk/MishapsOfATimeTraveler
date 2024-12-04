﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

namespace MOATT.Levels.Buildings
{
    using Health;
    using Tiles;
    using Units.Range;

    public class BuildingFacade : MonoBehaviour
    {
        public HealthModel HealthModel { get; private set; }
        public UnitRange BuildingRange { get; private set; }

        private Settings settings;
        private BuildingRegistry buildingRegistry;

        [System.Flags]
        public enum BuildingType
        {
            Common = 1,
            Tower = 2,
        }

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
            BuildingRegistry buildingRegistry
            )
        {
            this.settings = settings;
            this.buildingRegistry = buildingRegistry;

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

        public void Heal(float amount)
        {
            HealthModel.CurrentHealth += amount;
        }

        [System.Serializable]
        public class Settings
        {
            public TileBuilding.TileType canBePlacedOn;
            public BuildingType buildingType;
            public int nutsAndBoltsCost = 100;
        }

        public class Factory : PlaceholderFactory<Object, BuildingTunables, BuildingFacade> { }
    }
}
