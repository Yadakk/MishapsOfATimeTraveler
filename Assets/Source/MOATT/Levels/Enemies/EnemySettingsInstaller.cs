using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace MOATT.Levels.Enemies
{
    [CreateAssetMenu(fileName = nameof(EnemySettingsInstaller),
        menuName = "Installers/" + nameof(EnemySettingsInstaller))]
    public class EnemySettingsInstaller : ScriptableObjectInstaller
    {
        [SerializeField]
        private EnemyTowerDamager.Settings towerDamager;

        public override void InstallBindings()
        {
            Container.BindInstance(towerDamager);
        }
    }
}
