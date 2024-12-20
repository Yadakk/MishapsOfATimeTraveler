﻿using MOATT.Particles;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace MOATT.Levels.Buildings
{
    [CreateAssetMenu(
        fileName = "BuildingInstaller",
    menuName = "Installers/Buildings/Base")]
    public class BuildingSOI : ScriptableObjectInstaller
    {
        public BuildingFacade.Settings buildingFacade;

        public override void InstallBindings()
        {
            InstallSettings();
            Container.Install<BuildingInstaller>();
        }

        protected virtual void InstallSettings()
        {
            Container.BindInstance(buildingFacade);
        }
    }
}
