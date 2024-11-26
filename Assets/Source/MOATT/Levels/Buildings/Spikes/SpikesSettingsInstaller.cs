using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MOATT.Levels.Buildings.Spikes
{
    [CreateAssetMenu(
    fileName = "SpikesInstaller",
    menuName = "Installers/Buildings/Spikes")]
    public class SpikesSettingsInstaller : BuildingSOI
    {
        public SpikesEnemyDamager.Settings enemyDamager;
        public SpikesReloader.Settings reloader;

        public override void InstallBindings()
        {
            InstallSettings();
            Container.Install<SpikesInstaller>();
        }

        protected override void InstallSettings()
        {
            base.InstallSettings();

            Container.BindInstance(enemyDamager);
            Container.BindInstance(reloader);
        }
    }
}
