using MOATT.Levels.Units.Damage;
using MOATT.Levels.Units.ReloadTime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MOATT.Levels.Buildings.Spikes
{
    public class SpikesInstaller : BuildingInstaller
    {
        public override void InstallBindings()
        {
            base.InstallBindings();

            Container.Bind<UnitReloadTime>().AsSingle();
            Container.Bind<UnitDamage>().AsSingle();
            Container.BindInterfacesAndSelfTo<SpikesReloader>().AsSingle();
            Container.BindInterfacesAndSelfTo<SpikesEnemyDamager>().AsSingle();
        }
    }
}
