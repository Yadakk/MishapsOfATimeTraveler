using MOATT.Levels.BuildingPlacement;
using MOATT.Levels.Buildings;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace MOATT.Abilities.Types
{
    public class FastRechargeUpgradeAbility : Ability, IInitializable, IDisposable
    {
        private readonly Description description;
        private readonly BuildingRegistry buildingRegistry;
        private readonly Settings settings;
        private readonly BuildingPlacementSelectorVM[] selectorVMs;

        public FastRechargeUpgradeAbility(AbilityActiveDuration abilityActiveDuration, Description description, BuildingRegistry buildingRegistry, Settings settings, BuildingPlacementSelectorVM[] selectorVMs)
        {
            AbilityActiveDuration = abilityActiveDuration;
            this.description = description;
            this.buildingRegistry = buildingRegistry;
            this.settings = settings;
            this.selectorVMs = selectorVMs;
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

                for (int i = 0; i < selectorVMs.Length; i++)
                {
                    selectorVMs[i].BuildingInfo.AddMultiplier(this, settings.multiplier);
                }
            }
            else
            {
                buildingRegistry.OnBuildingAdded -= AddMultipliersToBuilding;
                for (int i = 0; i < buildingRegistry.buildings.Count; i++)
                {
                    RemoveMultipliersFromBuilding(buildingRegistry.buildings[i]);
                }

                for (int i = 0; i < selectorVMs.Length; i++)
                {
                    selectorVMs[i].BuildingInfo.RemoveMultiplier(this);
                }
            }
        }

        private void AddMultipliersToBuilding(BuildingFacade building)
        {
            if (building.BuildingUpgrader == null) return;
            building.BuildingUpgrader.AddMultiplier(this, settings.multiplier);
        }

        private void RemoveMultipliersFromBuilding(BuildingFacade building)
        {
            if (building.BuildingUpgrader == null) return;
            building.BuildingUpgrader.RemoveMultiplier(this);
        }

        public override string ToString() => description.ToString();

        [Serializable]
        public class Settings
        {
            public float duration = 30f;
            public float multiplier = 2f;
        }

        public class Description
        {
            public override string ToString()
            {
                return "All towers recharge and get upgraded twice as fast for 30 seconds";
            }
        }
    }
}