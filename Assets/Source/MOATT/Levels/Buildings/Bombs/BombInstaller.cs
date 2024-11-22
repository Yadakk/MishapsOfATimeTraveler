using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MOATT.Levels.Buildings.Bombs
{
    public class BombInstaller : BuildingInstaller
    {
        public override void InstallBindings()
        {
            base.InstallBindings();

            Container.BindInterfacesAndSelfTo<BombTimer>().AsSingle();
            Container.BindInterfacesAndSelfTo<BombExploder>().AsSingle();
        }
    }
}
