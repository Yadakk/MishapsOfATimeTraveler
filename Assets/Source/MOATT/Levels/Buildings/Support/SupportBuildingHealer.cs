using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using TimeTimers;
using Cannedenuum.ZenjectUtils.MonoInterfaces;

namespace MOATT.Levels.Buildings.Support
{
    using Units.Damage;
    using Units.Range;
    using MOATT.Levels.Units.ReloadTime;

    public class SupportBuildingHealer : IUpdatable
    {
        private readonly UnitReloadTime reloadTime;
        private readonly BuildingRegistry registry;
        private readonly Timer timer;
        private readonly UnitRange unitRange;
        private readonly BuildingFacade facade;
        private readonly UnitDamage unitDamage;
        private readonly Settings settings;

        public SupportBuildingHealer(UnitReloadTime reloadTime, BuildingRegistry registry, Timer timer, UnitRange unitRange, BuildingFacade facade, UnitDamage unitDamage, Settings settings)
        {
            this.reloadTime = reloadTime;
            this.registry = registry;
            this.timer = timer;
            this.unitRange = unitRange;
            this.facade = facade;
            this.unitDamage = unitDamage;
            this.settings = settings;
        }

        public void Update()
        {
            if (timer.Elapsed < reloadTime.Value) return;

            List<BuildingFacade> healableBuildings = new();
            foreach (var building in registry.buildings)
            {
                if (building == facade) continue;
                if (building.Type != settings.canHeal) continue;
                if (Vector3.Distance(building.transform.position, facade.transform.position) >= unitRange.Range) continue;
                if (building.HealthModel == null) continue;
                if (building.HealthModel.CurrentHealth >= building.HealthModel.MaxHealth) continue;
                healableBuildings.Add(building);
            }
            healableBuildings.ForEach(building => building.Heal(unitDamage.Value));

            timer.Reset();
        }

        [Serializable]
        public class Settings
        {
            public BuildingFacade.BuildingType canHeal;
        }
    }
}
