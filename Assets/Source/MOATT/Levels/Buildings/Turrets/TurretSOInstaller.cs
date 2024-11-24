using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MOATT.Levels.Buildings.Turrets
{
    using Health;

    [CreateAssetMenu(fileName = nameof(TurretSOInstaller),
        menuName = "Installers/Buildings/" + nameof(TurretSOInstaller))]
    public class TurretSOInstaller : BuildingSOInstaller
    {
        public TurretReloader.Settings reloader;
        public TurretShooter.Settings shooter;
        public HealthModel.Settings healthModel;

        public override void InstallBindings()
        {
            InstallSettings();
            Container.Install<TurretInstaller>();
        }

        protected override void InstallSettings()
        {
            base.InstallSettings();

            Container.BindInstance(healthModel);
            Container.BindInstance(reloader);
            Container.BindInstance(shooter);
        }
    }
}
