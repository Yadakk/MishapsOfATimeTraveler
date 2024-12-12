using MOATT.Levels.Units.Damage;
using MOATT.Levels.Units.ReloadTime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MOATT.Levels.Buildings.Bombs
{
    [CreateAssetMenu(
        fileName = "BombInstaller",
        menuName = "Installers/Buildings/Bomb")]
    public class BombSOInstaller : BuildingSOI
    {
        public BombInstaller.Settings bombInstaller;
        public UnitDamage.Settings damage;
        public UnitReloadTime.Settings reloadTime;

        public override void InstallBindings()
        {
            InstallSettings();
            Container.Install<BombInstaller>();
        }

        protected override void InstallSettings()
        {
            base.InstallSettings();

            Container.BindInstance(bombInstaller);
            Container.BindInstance(damage).AsSingle();
            Container.BindInstance(reloadTime).AsSingle();
        }
    }
}
