using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;
using Cannedenuum.ZenjectUtils.TubableFactories;

namespace MOATT.Levels.Waves
{
    using Enemies;

    public class WaveInstaller : Installer
    {
        public override void InstallBindings()
        {
            Container.Bind<EnemyRegistry>().AsSingle();
            Container.BindFactory<Object, EnemyTunables, EnemyFacade, EnemyFacade.Factory>().
                FromIFactory(x => x.To<TunablePrefabFactory<EnemyTunables, EnemyFacade>>().
                AsSingle().WithArguments("Enemies"));
            Container.Bind<StateFactory>().AsSingle();
        }
    }
}
