using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MOATT.Levels.Buildings.Bombs
{
    [CreateAssetMenu(fileName = nameof(BombSettingsInstaller),
        menuName = "Installers/Buildings/" +
        nameof(BombSettingsInstaller))]
    public class BombSettingsInstaller : BuildingSettingsInstaller
    {
        public BombExploder.Settings exploder;
        public BombTimer.Settings timer;

        public override void InstallBindings()
        {
            base.InstallBindings();

            Container.BindInstance(exploder).AsSingle();
            Container.BindInstance(timer).AsSingle();
        }
    }
}
