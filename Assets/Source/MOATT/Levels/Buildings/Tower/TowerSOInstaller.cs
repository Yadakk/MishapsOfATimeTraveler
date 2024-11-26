using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MOATT.Levels.Buildings.Tower
{
    using Health;

    [CreateAssetMenu(
        fileName = "TowerSOI",
        menuName = "Installers/Buildings/Tower")]
    public class TowerSOInstaller : BuildingSOI
    {
        public TowerInstaller.Settings towerInstallerSettings;

        public override void InstallBindings()
        {
            base.InstallBindings();
            Container.BindInstance(towerInstallerSettings);
            Container.Install<TowerInstaller>();
        }
    }
}
