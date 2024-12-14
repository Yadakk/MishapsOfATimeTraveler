using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace MOATT.Levels.Buildings.Tower
{
    using Units.Health;

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
            Container.BindInterfacesAndSelfTo<TowerLostInvoker>().AsSingle();
        }

        [Serializable]
        public class Settings
        {
            public UnitHealthInstaller.Settings unitHealth;
        }
    }
}
