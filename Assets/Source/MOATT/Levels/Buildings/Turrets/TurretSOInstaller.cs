using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MOATT.Levels.Buildings.Turrets
{
    [CreateAssetMenu(fileName = nameof(TurretSOInstaller),
        menuName = "Installers/Buildings/" + nameof(TurretSOInstaller))]
    public class TurretSOInstaller : BuildingSOInstaller
    {
        public TurretReloader.Settings reloader;
        public TurretTargetPicker.Settings targetPicker;
        public TurretShooter.Settings shooter;

        public override void InstallBindings()
        {
            InstallSettings();
            Container.Install<TurretInstaller>();
        }

        protected override void InstallSettings()
        {
            base.InstallSettings();

            Container.BindInstance(reloader);
            Container.BindInstance(targetPicker);
            Container.BindInstance(shooter);
        }
    }
}
