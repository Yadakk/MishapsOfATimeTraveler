﻿using MOATT.Levels.Economics;
using MOATT.Levels.Health;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using TimeTimers;
using UnityEngine;
using Zenject;

namespace MOATT.Levels.Buildings
{
    public class BuildingUpgrader : IDisposable, ITickable
    {
        private readonly Settings settings;
        private readonly PlayerResources playerResources;
        private readonly Timer timer;
        private readonly BuildingFacade facade;
        private readonly BuildingTunables tunables;
        private readonly BuildingFacade.Factory buildingFactory;

        private int workingScientists = 0;

        public BuildingUpgrader(Settings settings, PlayerResources playerResources, Timer timer, BuildingFacade facade, BuildingTunables tunables, BuildingFacade.Factory buildingFactory)
        {
            this.settings = settings;
            this.playerResources = playerResources;
            this.timer = timer;
            this.facade = facade;
            this.tunables = tunables;
            this.buildingFactory = buildingFactory;
        }

        public bool IsUpgrading { get; private set; }
        public BuildingFacade UpgradedPrefab => settings.nextLevelPrefab;

        public float UpgradeProgress { get; private set; }

        public void Dispose()
        {
            playerResources.BusyScientists -= workingScientists;
        }

        public void Tick()
        {
            if (!IsUpgrading) return;
            UpgradeProgress = timer.Elapsed / settings.upgradeTime;
            if (UpgradeProgress < 1f) return;
            playerResources.IdleScientists += workingScientists;
            buildingFactory.Create(settings.nextLevelPrefab, new(null, tunables.initTile));
            facade.Destroy();
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
