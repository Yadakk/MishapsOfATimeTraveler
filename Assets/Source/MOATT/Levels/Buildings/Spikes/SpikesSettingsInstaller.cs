using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MOATT.Levels.Buildings.Spikes
{
    [CreateAssetMenu(
    fileName = nameof(SpikesSettingsInstaller),
    menuName = "Installers/Buildings/" + nameof(SpikesSettingsInstaller))]
    public class SpikesSettingsInstaller : BuildingSettingsInstaller
    {
        public SpikesEnemyDamager.Settings enemyDamager;
        public SpikesReloader.Settings reloader;

        public override void InstallBindings()
        {
            base.InstallBindings();

            Container.BindInstance(enemyDamager);
            Container.BindInstance(reloader);
        }
    }
}
