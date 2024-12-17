using MOATT.Levels.Buildings;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace MOATT.Abilities.Types
{
    public class FastBuildingsAbility : Ability, IInitializable, IDisposable
    {
        private readonly Description description;
        private readonly BuildingRegistry buildingRegistry;
        private readonly Settings settings;

        public override Sprite Sprite => settings.sprite;

        public FastBuildingsAbility(AbilityActiveDuration abilityActiveDuration, Description description, BuildingRegistry buildingRegistry, Settings settings)
        {
            AbilityActiveDuration = abilityActiveDuration;
            this.description = description;
            this.buildingRegistry = buildingRegistry;
            this.settings = settings;
        }

        public void Initialize()
        {
            AbilityActiveDuration.duration = settings.duration;
            AbilityActiveDuration.OnActiveChanged += ActiveChangedHandler;
        }

        public void Dispose()
        {
            AbilityActiveDuration.OnActiveChanged -= ActiveChangedHandler;
        }

        public override void Activate()
        {
            AbilityActiveDuration.Activate();
        }

        private void ActiveChangedHandler(bool value)
        {
            if (value)
            {
                buildingRegistry.OnBuildingAdded += AddMultipliersToBuilding;
                for (int i = 0; i < buildingRegistry.buildings.Count; i++)
                {
                    AddMultipliersToBuilding(buildingRegistry.buildings[i]);
                }
            }
            else
            {
                buildingRegistry.OnBuildingAdded -= AddMultipliersToBuilding;
                for (int i = 0; i < buildingRegistry.buildings.Count; i++)
                {
                    RemoveMultipliersFromBuilding(buildingRegistry.buildings[i]);
                }
            }
        }

        private void AddMultipliersToBuilding(BuildingFacade building)
        {
            if (building.MultiplyableBuildingReloader == null) return;
            building.MultiplyableBuildingReloader.AddMultiplier(this, settings.multiplier);
        }

        private void RemoveMultipliersFromBuilding(BuildingFacade building)
        {
            if (building.MultiplyableBuildingReloader == null) return;
            building.MultiplyableBuildingReloader.RemoveMultiplier(this);
        }

        public override string ToString() => description.ToString();

        [Serializable]
        public class Settings
        {
            public float duration = 30f;
            public float multiplier = 0.5f;
            public Sprite sprite;
        }

        public class Description
        {
            public override string ToString()
            {
                return "All turrets, spikes and support towers act twice as fast for 30 seconds";
            }
        }
    }
}
