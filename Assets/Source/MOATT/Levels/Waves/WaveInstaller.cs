﻿using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;
using Cannedenuum.ZenjectUtils.TubableFactories;

namespace MOATT.Levels.Waves
{
    using Enemies;

    public class WaveInstaller : Installer
    {
        private readonly Settings settings;

        public WaveInstaller(Settings settings)
        {
            this.settings = settings;
        }

        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<WaveStateMachine>().AsSingle().WithArguments(settings.waveStateMachine);
            Container.Bind<EnemyRegistry>().AsSingle();
            Container.BindFactory<Object, EnemyTunables, EnemyFacade, EnemyFacade.Factory>().
                FromIFactory(x => x.To<TunablePrefabFactory<EnemyTunables, EnemyFacade>>().
                AsSingle().WithArguments("Enemies"));
            Container.Bind<StateFactory>().AsSingle();

            Container.Bind<SpawnChanceDistribution>().AsSingle().WithArguments(settings.spawnChanceDistribution);
            Container.Bind<WaveInfo>().AsSingle();
        }

        [System.Serializable]
        public class Settings
        {
            public SpawnChanceDistribution.Settings spawnChanceDistribution;
            public WaveStateMachine.Settings waveStateMachine;
        }
    }
}
