using Cannedenuum.ZenjectUtils.MonoInterfaces;
using MOATT.Levels.Economics;
using MOATT.Levels.Health;
using MOATT.Levels.PrototypePool;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using TimeTimers;
using UnityEngine;
using Zenject;

namespace MOATT.Levels.Buildings
{
    public class BuildingUpgrader : IDisposable, IStartable, ITickable
    {
        private readonly Settings settings;
        private readonly PlayerResources playerResources;
        private readonly Timer timer;
        private readonly BuildingFacade facade;
        private readonly BuildingTunables tunables;
        private readonly BuildingPrototypePool buildingPrototypePool;
        private BuildingFacade nextLevelPrototype;
        private readonly BuildingFacade.Factory buildingFactory;

        private int workingScientists = 0;

        public event Action OnUpgradeComplete;

        public BuildingUpgrader(Settings settings, PlayerResources playerResources, Timer timer, BuildingFacade facade, BuildingTunables tunables, BuildingPrototypePool buildingPrototypePool = null, BuildingFacade.Factory buildingFactory = null)
        {
            this.settings = settings;
            this.playerResources = playerResources;
            this.timer = timer;
            this.facade = facade;
            this.tunables = tunables;
            this.buildingPrototypePool = buildingPrototypePool;
            this.buildingFactory = buildingFactory;
        }

        public bool IsUpgrading { get; private set; }
        public BuildingFacade UpgradedPrefab => settings.nextLevelPrefab;

        public float UpgradeProgress { get; private set; }

        public void Start()
        {
            if (settings.nextLevelPrefab == null) return;
            nextLevelPrototype = buildingPrototypePool.GetPrototype(settings.nextLevelPrefab);
        }

        public void Tick()
        {
            if (!IsUpgrading) return;
            UpgradeProgress = timer.Elapsed / settings.upgradeTime;
            if (UpgradeProgress < 1f) return;
            playerResources.IdleScientists += workingScientists;
            buildingFactory.Create(nextLevelPrototype, new(null, tunables.initTile)).gameObject.SetActive(true);
            facade.Destroy();
            OnUpgradeComplete?.Invoke();
        }

        public void Dispose()
        {
            playerResources.BusyScientists -= workingScientists;
        }

        public bool TryUpgrade()
        {
            if (playerResources.NutsAndBolts < settings.nutsAndBoltsCost) return false;
            if (playerResources.IdleScientists < settings.scientistsCost) return false;
            if (IsUpgrading) return false;
            Upgrade();
            return true;
        }

        private void Upgrade()
        {
            playerResources.NutsAndBolts -= settings.nutsAndBoltsCost;
            playerResources.IdleScientists -= settings.scientistsCost;
            workingScientists += settings.scientistsCost;
            playerResources.BusyScientists += workingScientists;
            timer.Reset();
            IsUpgrading = true;
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new();
            stringBuilder.AppendLine($"Upgrade to next level at cost of {settings.nutsAndBoltsCost} Nuts And Bolts.");
            stringBuilder.AppendLine($"Will temporarily send {settings.scientistsCost} scientists.");
            stringBuilder.AppendLine($"Upgrade takes {settings.upgradeTime} seconds.");
            stringBuilder.AppendLine($"Next level stats:");
            stringBuilder.Append(nextLevelPrototype.ToStringNoCost());
            return stringBuilder.ToString();
        }

        [Serializable]
        public class Settings
        {
            public BuildingFacade nextLevelPrefab;
            public int nutsAndBoltsCost;
            public int scientistsCost;
            public float upgradeTime;
        }
    }
}
