using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace MOATT.Installers
{
    using Levels.BillboardGroup;
    using Levels.Billboards;
    using Layers;
    using MOATT.Levels.Economics;
    using MOATT.Levels.BuildingSelection;

    [CreateAssetMenu(fileName = nameof(GameSettingsInstaller),
        menuName = "Installers/" + nameof(GameSettingsInstaller))]
    public class GameSettingsInstaller : ScriptableObjectInstaller
    {
        public Levels.Units.Health.UnitHealthInstaller.GlobalSettings unitHealthInstallers;
        public BillboardGroupInstaller.GlobalSettings billboardGroupInstaller;
        public BillboardSource.Settings billboardSource;
        public LayerMasks layerMasks;
        public Levels.LevelCamera.RTSCameraRotater.Settings rtsCameraRotater;
        public ScientistBuyerVM.Settings scientistBuyerVM;
        public BuildingSelectionInstaller.Settings buildingSelecton;
        public ScientistRechargeMultiplier.Settings scientistRechargeMultiplier;

        public override void InstallBindings()
        {
            Container.BindInstance(billboardSource);
            Container.BindInstance(billboardGroupInstaller);
            Container.BindInstance(unitHealthInstallers);
            Container.BindInstance(layerMasks);
            Container.BindInstance(rtsCameraRotater);
            Container.BindInstance(scientistBuyerVM);
            Container.BindInstance(buildingSelecton);
            Container.BindInstance(scientistRechargeMultiplier);
        }
    }
}
