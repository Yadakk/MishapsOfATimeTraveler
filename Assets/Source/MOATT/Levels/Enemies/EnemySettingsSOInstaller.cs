using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace MOATT.Levels.Enemies
{
    using Levels.UnitHealth;

    [CreateAssetMenu(
        fileName = "EnemyInstaller",
        menuName = "Installers/Enemy")]
    public class EnemySettingsSOInstaller : ScriptableObjectInstaller
    {
        public EnemyTowerDamager.Settings towerDamager;
        public EnemyInstaller.Settings installerSettings;
        public EnemyPathfinder.Settings enemyPathfinder;

        public override void InstallBindings()
        {
            InstallSettings();
            Container.Install<EnemyInstaller>();
        }

        protected virtual void InstallSettings()
        {
            Container.BindInstance(towerDamager);
            Container.BindInstance(enemyPathfinder);
            Container.BindInstance(installerSettings);
        }
    }
}
