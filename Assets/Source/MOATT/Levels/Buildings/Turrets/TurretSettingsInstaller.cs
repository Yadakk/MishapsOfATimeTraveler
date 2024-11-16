using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MOATT.Levels.Buildings.Turrets
{
    [CreateAssetMenu(fileName = nameof(TurretSettingsInstaller),
        menuName = "Installers/Buildings/" + nameof(TurretSettingsInstaller))]
    public class TurretSettingsInstaller : BuildingSettingsInstaller
    {
        public TurretInstaller.Settings installer;
        public TurretReloader.Settings reloader;
        public TurretTargetPicker.Settings targetPicker;

        public override void InstallBindings()
        {
            base.InstallBindings();

            Container.BindInstance(installer);
            Container.BindInstance(reloader);
            Container.BindInstance(targetPicker);
        }
    }
}
