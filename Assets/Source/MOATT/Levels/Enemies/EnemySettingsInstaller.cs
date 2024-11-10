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
        [SerializeField]
        private EnemyTowerDamager.Settings towerDamager;

        [SerializeField]
        private HealthModel.Settings healthModel;

        public override void InstallBindings()
        {
            Container.BindInstance(towerDamager);
            Container.BindInstance(healthModel);
        }
    }
}
