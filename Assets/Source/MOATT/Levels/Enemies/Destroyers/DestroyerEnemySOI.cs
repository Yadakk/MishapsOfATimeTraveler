using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MOATT.Levels.Enemies.Destroyers
{
    [CreateAssetMenu(fileName = "DestroyerEnemySOI", menuName = "Installers/Enemies/Destroyer")]
    public class DestroyerEnemySOI : EnemySOI
    {
        public DestroyerEnemyInstaller.Settings destroyerEnemy;

        public override void InstallBindings()
        {
            base.InstallBindings();
            Container.BindInstance(destroyerEnemy);
            Container.Install<DestroyerEnemyInstaller>();
        }
    }
}
