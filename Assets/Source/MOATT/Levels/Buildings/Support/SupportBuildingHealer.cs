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
    using System.Linq;

    public class SupportBuildingHealer : IUpdatable
    {
        private readonly Settings settings;
        private readonly BuildingRegistry registry;
        private readonly Timer timer;
        private readonly UnitRange unitRange;
        private readonly BuildingFacade facade;
        private readonly UnitDamage unitDamage;

        public SupportBuildingHealer(Settings settings, BuildingRegistry registry = null, Timer timer = null, UnitRange unitRange = null, BuildingFacade facade = null, UnitDamage unitDamage = null)
        {
            this.settings = settings;
            this.registry = registry;
            this.timer = timer;
            this.unitRange = unitRange;
            this.facade = facade;
            this.unitDamage = unitDamage;
        }

        public void Update()
        {
            if (timer.Elapsed < settings.reloadTime) return;

            List<BuildingFacade> healableBuildings = new();
            foreach (var building in registry.buildings)
            {
                if (building == facade) continue;
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
            public float reloadTime = 2f;
        }
    }
}
