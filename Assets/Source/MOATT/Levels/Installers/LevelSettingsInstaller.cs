using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace MOATT.Levels.Installers
{
    using Economics;
    using MOATT.Levels.GameplayConditions;
    using MOATT.Levels.Waves;
    using Waves.States;

    [CreateAssetMenu(
        fileName = nameof(LevelSettingsInstaller), 
        menuName = "Installers/" + nameof(LevelSettingsInstaller), 
        order = 51)]
    public class LevelSettingsInstaller : ScriptableObjectInstaller
    {
        public WaveSettings waves;
        public PlayerResources.Settings playerResources;
        public LevelProgress.Settings levelProgress;

        public override void InstallBindings()
        {
            InstallWaves();
            Container.BindInstance(playerResources).AsSingle();
        }

        private void InstallWaves()
        {
            Container.BindInstance(waves.waveInstaller);
            Container.BindInstance(waves.delay);
            Container.BindInstance(waves.spawning);
            Container.BindInstance(levelProgress);
        }

        [System.Serializable]
        public class WaveSettings
        {
            public WaveInstaller.Settings waveInstaller;
            public Delay.Settings delay;
            public Spawning.Settings spawning;
        }
    }
}
