using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MOATT.Levels.Buildings.Tower
{
    using Health;

    [CreateAssetMenu(
        fileName = "TowerSOI",
        menuName = "Installers/Buildings/Tower")]
    public class TowerSOInstaller : BuildingSOInstaller
    {
        public TowerInstaller.Settings towerInstallerSettings;

        public override void InstallBindings()
        {
            InstallSettings();
            Container.Install<TowerInstaller>();
        }

        protected override void InstallSettings()
        {
            Container.BindInstance(towerInstallerSettings);
            base.InstallSettings();
        }
    }
}
