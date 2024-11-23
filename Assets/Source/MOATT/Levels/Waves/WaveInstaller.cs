using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace MOATT.Levels.Waves
{
    using Enemies;
    using InstallerParamFactories;

    public class WaveInstaller : Installer
    {
        public override void InstallBindings()
        {
            Container.Bind<EnemyRegistry>().AsSingle();
            Container.BindFactory<Object, EnemyTunables, EnemyFacade, EnemyFacade.Factory>().
                FromFactory<TunablePrefabFactory<EnemyTunables, EnemyFacade>>();
            Container.Bind<StateFactory>().AsSingle();
        }
    }
}
