using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MOATT.Levels.Buildings.Turrets
{
    using Health;

    [CreateAssetMenu(
        fileName = "TurretSOI",
        menuName = "Installers/Buildings/Turret")]
    public class TurretSOInstaller : BuildingSOInstaller
    {
        public TurretReloader.Settings reloader;
        public TurretShooter.Settings shooter;
        public TurretInstaller.Settings turretInstaller;

        public override void InstallBindings()
        {
            InstallSettings();
            Container.Install<TurretInstaller>();
        }

        protected override void InstallSettings()
        {
            base.InstallSettings();

            Container.BindInstance(turretInstaller);
            Container.BindInstance(reloader);
            Container.BindInstance(shooter);
        }
    }
}
