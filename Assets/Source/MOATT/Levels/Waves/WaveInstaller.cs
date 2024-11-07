using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zenject;

namespace MOATT.Levels.Waves
{
    using States;

    public class WaveInstaller : Installer
    {
        public override void InstallBindings()
        {
            Container.BindFactory<Delay, Delay.Factory>();
            Container.BindFactory<Spawning, Spawning.Factory>();
            Container.BindFactory<EnemiesAlive, EnemiesAlive.Factory>();
            Container.Bind<WaveInfo>().AsSingle();
            Container.Bind<StateFactory>().AsSingle();
        }
    }
}
