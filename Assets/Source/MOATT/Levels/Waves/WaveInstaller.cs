using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zenject;

namespace MOATT.Levels.Waves
{
    using Enemies;

    public class WaveInstaller : Installer
    {
        public override void InstallBindings()
        {
            Container.Bind<EnemyRegistry>().AsSingle();
            Container.Bind<StateFactory>().AsSingle();
        }
    }
}
