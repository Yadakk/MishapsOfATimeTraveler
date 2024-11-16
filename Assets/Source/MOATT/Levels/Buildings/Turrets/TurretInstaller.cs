using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace MOATT.Levels.Buildings.Turrets
{
    using Bullets;
    using Enemies;

    public class TurretInstaller : MonoInstaller
    {
        private Settings settings;

        [Inject]
        public void Construct(Settings settings)
        {
            this.settings = settings;
        }

        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<TurretTargetPicker>().AsSingle();
            Container.BindInterfacesAndSelfTo<TurretRotater>().AsSingle();
            Container.BindInterfacesAndSelfTo<TurretReloader>().AsSingle();
            Container.Bind<TurretShooter>().FromComponentInHierarchy().AsSingle();
            Container.BindFactory<BulletFacade, BulletFacade.Factory>().
                FromComponentInNewPrefab(settings.bulletPrefab).
                UnderTransform(new GameObject("Bullets").transform);
        }

        [System.Serializable]
        public class Settings 
        {
            public BulletFacade bulletPrefab;
        }
    }
}
