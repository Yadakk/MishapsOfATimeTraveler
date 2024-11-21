using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace MOATT.Levels.Enemies
{
    using Health;

    [CreateAssetMenu(fileName = nameof(EnemySettingsInstaller),
        menuName = "Installers/" + nameof(EnemySettingsInstaller))]
    public class EnemySettingsInstaller : ScriptableObjectInstaller
    {
        public EnemyTowerDamager.Settings towerDamager;
        public HealthModel.Settings healthModel;
        public EnemyPathfinder.Settings enemyPathfinder;

        public override void InstallBindings()
        {
            Container.BindInstance(towerDamager);
            Container.BindInstance(healthModel);
            Container.BindInstance(enemyPathfinder);
        }
    }
}
