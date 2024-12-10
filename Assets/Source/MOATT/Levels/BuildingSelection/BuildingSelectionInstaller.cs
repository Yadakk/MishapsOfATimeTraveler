﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace MOATT.Levels.BuildingSelection
{
    public class BuildingSelectionInstaller : Installer
    {
        private readonly Settings settings;

        public BuildingSelectionInstaller(Settings settings)
        {
            this.settings = settings;
        }

        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<BuildingSelectionHoverer>().AsSingle();
            Container.BindInterfacesAndSelfTo<BuildingSelectionSelector>().AsSingle();
            Container.BindInterfacesAndSelfTo<BuildingSelectionInputBinder>().AsSingle();
            Container.BindInterfacesAndSelfTo<BuildingSelectionOutlineColorizer>().AsSingle().WithArguments(settings.outlineColorizer);
        }

        [Serializable]
        public class Settings
        {
            public BuildingSelectionOutlineColorizer.Settings outlineColorizer;
        }
    }
}
