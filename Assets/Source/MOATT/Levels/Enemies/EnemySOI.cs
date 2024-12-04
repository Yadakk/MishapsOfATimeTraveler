using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace MOATT.Levels.Enemies
{
    using Units.Health;

    [CreateAssetMenu(
        fileName = "EnemySOI",
        menuName = "Installers/Enemy")]
    public class EnemySOI : ScriptableObjectInstaller
    {
        public EnemyInstaller.Settings enemy;

        public override void InstallBindings()
        {
            Container.BindInstance(enemy);
            Container.Install<EnemyInstaller>();
        }
    }
}