using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MOATT.Levels.Buildings.Turrets
{
    using Health;
    using MOATT.Levels.Units.Damage;
    using MOATT.Levels.Units.ReloadTime;

    [CreateAssetMenu(
        fileName = "TurretSOI",
        menuName = "Installers/Buildings/Turret")]
    public class TurretSOInstaller : BuildingSOI
    {
        public UnitReloadTime.Settings reloadTime;
        public TurretShooter.Settings shooter;
        public TurretInstaller.Settings turretInstaller;
        public UnitDamage.Settings unitDamage;

        public override void InstallBindings()
        {
            InstallSettings();
            Container.Install<TurretInstaller>();
        }

        protected override void InstallSettings()
        {
            base.InstallSettings();

            Container.BindInstance(turretInstaller);
            Container.BindInstance(reloadTime);
            Container.BindInstance(shooter);
            Container.BindInstance(unitDamage);
        }
    }
}
