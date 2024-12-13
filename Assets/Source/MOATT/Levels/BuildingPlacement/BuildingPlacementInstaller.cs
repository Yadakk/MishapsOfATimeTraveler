using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using Cannedenuum.ZenjectUtils.TubableFactories;

namespace MOATT.Levels.BuildingPlacement
{
    using InputLogic;
    using Buildings;

    public class BuildingPlacementInstaller : Installer
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<InputAssetMapSwapper>().AsCached();
            Container.BindInterfacesAndSelfTo<BuildingPlacementPlacer>().AsSingle();
            Container.BindInterfacesAndSelfTo<BuildingPlacementInputBinder>().AsSingle();
            Container.BindInterfacesAndSelfTo<BuildingPlacementHologram>().AsSingle();
            Container.BindInterfacesAndSelfTo<BuildingPlacementSelector>().AsSingle();
            Container.Bind<BuildingPlacementRange>().AsSingle();

            Container.BindFactory<Object, BuildingTunables, BuildingFacade, BuildingFacade.Factory>().
                FromIFactory(x => x.To<TunablePrefabFactory<BuildingTunables, BuildingFacade>>().
                AsSingle().WithArguments("Buildings"));

            Container.Bind<BuildingPlacementBuildingInfo>().AsTransient().
                OnInstantiated((context, obj) =>
                {
                    if (obj is ITickable tickable)
                        context.Container.Resolve<TickableManager>().Add(tickable);

                    if (obj is IInitializable initializable)
                        context.Container.Resolve<InitializableManager>().Add((IInitializable)obj);
                });
        }
    }
}
