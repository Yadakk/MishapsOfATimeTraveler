using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using TimeTimers;

namespace MOATT.Installers
{
    using GUILogic;
    using MOATT.Utils;

    public class GameInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<Timer>().AsTransient();
            Container.Bind<ScalableTimer>().AsTransient().
                OnInstantiated((context, obj) =>
                {
                    if (obj is ITickable tickable)
                        context.Container.Resolve<TickableManager>().Add(tickable);
                });
                

            Container.Bind<InputAsset>().AsSingle();
            Container.BindInterfacesAndSelfTo<PointerOverUIWatcher>().AsSingle();
        }
    }
}
