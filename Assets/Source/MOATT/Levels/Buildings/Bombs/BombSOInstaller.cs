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
        public BombExploder.Settings exploder;
        public BombTimer.Settings timer;

        public override void InstallBindings()
        {
            InstallSettings();
            Container.Install<BombInstaller>();
        }

        protected override void InstallSettings()
        {
            base.InstallSettings();

            Container.BindInstance(bombInstaller);
            Container.BindInstance(exploder).AsSingle();
            Container.BindInstance(timer).AsSingle();
        }
    }
}
