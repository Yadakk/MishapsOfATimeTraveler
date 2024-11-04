using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using Zenject.Asteroids;
using MOATT.Map.Waves;

namespace MOATT.Zenject
{
    [CreateAssetMenu(fileName = "SettingsInstaller", menuName = "Installers/Settings Installer", order = 51)]
    public class GameSettingsInstaller : ScriptableObjectInstaller
    {
        [SerializeField]
        private LevelInstaller.Settings levelInstaller;

        [SerializeField]
        private WaveSpawner.Settings waves;

        public override void InstallBindings()
        {
            Container.BindInstance(levelInstaller);
            Container.BindInstance(waves);
        }
    }
}
