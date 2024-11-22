using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MOATT.Levels.Buildings.Turrets
{
    using HealthBuildings;

    [CreateAssetMenu(fileName = nameof(TurretSettingsInstaller),
        menuName = "Installers/Buildings/HealthBuildings/" + nameof(TurretSettingsInstaller))]
    public class TurretSettingsInstaller : HealthBuildingSettingsInstaller
    {
        public TurretReloader.Settings reloader;
        public TurretTargetPicker.Settings targetPicker;
        public TurretShooter.Settings shooter;

        public override void InstallBindings()
        {
            base.InstallBindings();

            Container.BindInstance(reloader);
            Container.BindInstance(targetPicker);
            Container.BindInstance(shooter);
        }
    }
}
