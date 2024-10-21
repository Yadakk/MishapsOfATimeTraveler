using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using Zenject.Asteroids;

namespace MishapsOfATimeTraveler.GameAssembly
{
    [CreateAssetMenu(fileName = "SettingsInstaller", menuName = "Installers/Settings Installer", order = 51)]
    public class SettingsInstaller : ScriptableObjectInstaller
    {
        [SerializeField]
        private LevelInstaller.Settings levelInstaller;

        public override void InstallBindings()
        {
            Container.BindInstance(levelInstaller);
        }
    }
}
