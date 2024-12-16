using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using TimeTimers;

namespace MOATT.Installers
{
    using GUILogic;
    using MOATT.Abilities;
    using MOATT.Abilities.Types;
    using MOATT.Utils;
    using System;

    public class GameInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<Timer>().AsTransient();
            Container.Bind<ScalableTimer>().AsTransient().OnInstantiated(AddToTickableManager);
            Container.Bind<InputAsset>().AsSingle();
            Container.BindInterfacesAndSelfTo<PointerOverUIWatcher>().AsSingle();
            Container.BindInterfacesAndSelfTo<SelectedAbilityType>().AsSingle();
            Container.Bind<AbilityActiveDuration>().AsTransient().OnInstantiated(AddToTickableManager);

            InstallAbilityDescriptions();
        }

        private void InstallAbilityDescriptions()
        {
            Container.BindInterfacesAndSelfTo<AbilityDescriptionDictionary>().AsSingle();
            Container.Bind<RewindAbility.Description>().AsSingle();
            Container.Bind<SlowEnemiesAbility.Description>().AsSingle();
        }

        private void AddToTickableManager(InjectContext context, object obj)
        {
            if (obj is not ITickable tickable) return;
            context.Container.Resolve<TickableManager>().Add(tickable);
        }
    }
}
