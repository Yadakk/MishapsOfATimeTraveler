using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using Zenject.Asteroids;
using MOATT.Map.Waves.States;

namespace MOATT.Zenject
{
    [CreateAssetMenu(fileName = "SettingsInstaller", menuName = "Installers/Settings Installer", order = 51)]
    public class GameSettingsInstaller : ScriptableObjectInstaller
    {
        [SerializeField]
        private LevelInstaller.Settings levelInstaller;

        [SerializeField]
        private WaveSettings waveSettings;

        public override void InstallBindings()
        {
            Container.BindInstance(levelInstaller);
            BindWaves();
        }

        private void BindWaves()
        {
            Container.BindInstance(waveSettings.spawning);
        }

        [System.Serializable]
        public class WaveSettings
        {
            public Spawning.Settings spawning;
        }
    }
}
