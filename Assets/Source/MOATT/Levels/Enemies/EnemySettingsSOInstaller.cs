using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace MOATT.Levels.Enemies
{
    using Health;

    [CreateAssetMenu(
        fileName = "EnemyInstaller",
        menuName = "Installers/Enemy")]
    public class EnemySettingsSOInstaller : ScriptableObjectInstaller
    {
        public EnemyTowerDamager.Settings towerDamager;
        public HealthModel.Settings healthModel;
        public EnemyPathfinder.Settings enemyPathfinder;

        public override void InstallBindings()
        {
            InstallSettings();
            Container.Install<EnemyInstaller>();
        }

        protected virtual void InstallSettings()
        {
            Container.BindInstance(towerDamager);
            Container.BindInstance(healthModel);
            Container.BindInstance(enemyPathfinder);
        }
    }
}
