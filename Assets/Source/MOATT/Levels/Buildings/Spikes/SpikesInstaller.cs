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

            Container.BindInterfacesAndSelfTo<SpikesReloader>().AsSingle();
            Container.BindInterfacesAndSelfTo<SpikesEnemyDamager>().AsSingle();
        }
    }
}
