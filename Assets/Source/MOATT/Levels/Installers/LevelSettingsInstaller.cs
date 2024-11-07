using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using Zenject.Asteroids;
using MOATT.Levels.Waves.States;

namespace MOATT.Levels.Installers
{
    [CreateAssetMenu(fileName = "LevelSettingsInstaller", menuName = "Installers/Level Settings Installer", order = 51)]
    public class LevelSettingsInstaller : ScriptableObjectInstaller
    {
        [SerializeField]
        private LevelInstaller.Settings levelInstaller;

        [SerializeField]
        private WaveSettings waves;

        public override void InstallBindings()
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
