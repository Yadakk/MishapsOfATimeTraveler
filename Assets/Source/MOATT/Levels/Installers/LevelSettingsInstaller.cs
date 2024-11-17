using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace MOATT.Levels.Installers
{
    using Waves.States;

    [CreateAssetMenu(fileName = nameof(LevelSettingsInstaller), menuName = "Installers/" + nameof(LevelSettingsInstaller), order = 51)]
    public class LevelSettingsInstaller : ScriptableObjectInstaller
    {
        [SerializeField]
        private LevelInstaller.Settings levelInstaller;

        [SerializeField]
        private WaveSettings waves;

        public override void InstallBindings()
        {
            InstallWaves();
        }

        private void InstallWaves()
        {
            Container.BindInstance(levelInstaller);
            Container.BindInstance(waves.delay);
            Container.BindInstance(waves.spawning);
        }

        [System.Serializable]
        public class WaveSettings
        {
            public Delay.Settings delay;
            public Spawning.Settings spawning;
        }
    }
}
