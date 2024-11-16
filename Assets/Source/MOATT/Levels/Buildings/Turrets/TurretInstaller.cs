using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace MOATT.Levels.Buildings.Turrets
{
    using Bullets;
    using TransformGrouping;

    public class TurretInstaller : MonoInstaller
    {
        private Settings settings;
        private TransformGrouper grouper;

        [Inject]
        public void Construct(Settings settings, TransformGrouper grouper)
        {
            this.settings = settings;
            this.grouper = grouper;
        }

        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<TurretTargetPicker>().AsSingle();
            Container.BindInterfacesAndSelfTo<TurretRotater>().AsSingle();
            Container.BindInterfacesAndSelfTo<TurretReloader>().AsSingle();
            Container.Bind<TurretShooter>().FromComponentInHierarchy().AsSingle();
            Container.BindFactory<BulletFacade, BulletFacade.Factory>().
                FromComponentInNewPrefab(settings.bulletPrefab).
                UnderTransform(grouper.GetGroup("Bullets"));
        }

        [System.Serializable]
        public class Settings 
        {
            public BulletFacade bulletPrefab;
        }
    }
}
