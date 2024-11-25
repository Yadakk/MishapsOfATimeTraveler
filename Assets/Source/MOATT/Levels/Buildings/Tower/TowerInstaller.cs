﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace MOATT.Levels.Buildings.Tower
{
    using Levels.UnitHealth;

    public class TowerInstaller : Installer
    {
        private readonly Settings settings;

        public TowerInstaller(Settings settings)
        {
            this.settings = settings;
        }

        public override void InstallBindings()
        {
            Container.BindInstance(settings.unitHealth);
            Container.Install<UnitHealthInstaller>();
        }

        [Serializable]
        public class Settings
        {
            public UnitHealthInstaller.Settings unitHealth;
        }
    }
}