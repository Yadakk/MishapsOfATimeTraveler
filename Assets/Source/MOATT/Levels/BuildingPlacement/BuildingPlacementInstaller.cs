﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace MOATT.Levels.BuildingPlacement
{
    using InputLogic;
    using Buildings;
    using Tiles;

    public class BuildingPlacementInstaller : Installer
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<InputAssetMapSwapper>().AsCached();
            Container.BindInterfacesAndSelfTo<BuildingPlacementPlacer>().AsSingle();
            Container.BindInterfacesAndSelfTo<BuildingPlacementInputBinder>().AsSingle();
            Container.BindInterfacesAndSelfTo<BuildingPlacementHologram>().AsSingle();
            Container.BindInterfacesAndSelfTo<BuildingPlacementSelector>().AsSingle();
            Container.BindFactory<Object, TileBuilding, BuildingFacade, BuildingFacade.Factory>().
                FromFactory<PrefabFactory<TileBuilding, BuildingFacade>>();
        }
    }
}
