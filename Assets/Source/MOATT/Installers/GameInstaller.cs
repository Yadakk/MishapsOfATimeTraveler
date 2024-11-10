using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using TimeTimers;

namespace MOATT.Installers
{
    public class GameInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<Timer>().AsTransient();
        }
    }
}
