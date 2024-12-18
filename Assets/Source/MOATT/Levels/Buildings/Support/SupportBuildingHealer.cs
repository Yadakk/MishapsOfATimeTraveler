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
    using System.Linq;
    using MOATT.Utils;

    public class SupportBuildingHealer : IUpdatable, IMultiplyableBuildingReloader
    {
        private readonly Dictionary<object, float> multipliers = new();

        private readonly UnitReloadTime reloadTime;
        private readonly BuildingRegistry registry;
        private readonly ScalableTimer timer;
        private readonly UnitRange unitRange;
        private readonly BuildingFacade facade;
        private readonly UnitDamage unitDamage;
        private readonly Settings settings;

        public SupportBuildingHealer(UnitReloadTime reloadTime, BuildingRegistry registry, ScalableTimer timer, UnitRange unitRange, BuildingFacade facade, UnitDamage unitDamage, Settings settings)
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
                if (!building.Healable) continue;
                if (Vector3.Distance(building.transform.position, facade.transform.position) >= unitRange.Range) continue;
                if (building.HealthModel == null) continue;
                if (building.HealthModel.CurrentHealth >= building.HealthModel.MaxHealth) continue;
                healableBuildings.Add(building);
            }
            healableBuildings.ForEach(building => building.Heal(unitDamage.Value));

            timer.Reset();
        }

        public void AddMultiplier(object obj, float value)
        {
            if (multipliers.ContainsKey(obj)) return;
            multipliers.Add(obj, value);
            RecalculateMultiplier();
        }

        public void RemoveMultiplier(object obj)
        {
            if (!multipliers.ContainsKey(obj)) return;
            multipliers.Remove(obj);
            RecalculateMultiplier();
        }

        private void RecalculateMultiplier()
        {
            float totalMultiplier = 1f;

            for (int i = 0; i < multipliers.Count; i++)
            {
                totalMultiplier *= multipliers.ElementAt(i).Value;
            }

            timer.timeScale = totalMultiplier;
        }

        [Serializable]
        public class Settings
        {
            public BuildingFacade.BuildingType canHeal;
        }
    }
}
