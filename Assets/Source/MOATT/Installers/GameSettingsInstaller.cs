﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace MOATT.Installers
{
    using Levels.BillboardGroup;
    using Levels.Billboards;
    using Layers;

    [CreateAssetMenu(fileName = nameof(GameSettingsInstaller),
        menuName = "Installers/" + nameof(GameSettingsInstaller))]
    public class GameSettingsInstaller : ScriptableObjectInstaller
    {
        public Levels.Units.Health.UnitHealthInstaller.GlobalSettings unitHealthInstallers;
        public BillboardGroupInstaller.GlobalSettings billboardGroupInstaller;
        public BillboardSource.Settings billboardSource;
        public LayerMasks layerMasks;
        public Levels.LevelCamera.RTSCameraRotater.Settings rtsCameraRotater;

        public override void InstallBindings()
        {
            Container.BindInstance(billboardSource);
            Container.BindInstance(billboardGroupInstaller);
            Container.BindInstance(unitHealthInstallers);
            Container.BindInstance(layerMasks);
            Container.BindInstance(rtsCameraRotater);
        }
    }
}
