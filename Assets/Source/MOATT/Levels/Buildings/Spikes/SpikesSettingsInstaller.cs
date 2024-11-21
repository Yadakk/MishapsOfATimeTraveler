using MOATT.Levels.Installers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace MOATT.Levels.Buildings.Spikes
{
    [CreateAssetMenu(
    fileName = nameof(SpikesSettingsInstaller),
    menuName = "Installers/Buildings/" + nameof(SpikesSettingsInstaller))]
    public class SpikesSettingsInstaller : ScriptableObjectInstaller
    {
        public SpikesEnemyDamager.Settings enemyDamager;
        public SpikesReloader.Settings reloader;

        public override void InstallBindings()
        {
            Container.BindInstance(enemyDamager);
            Container.BindInstance(reloader);
        }
    }
}
