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
    using MOATT.Levels.Enemies;
    using MOATT.Abilities.Types;
    using MOATT.Abilities;
    using MOATT.Particles;

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
        public EnemyPathHistory.Settings pathHistory;

        public RewindAbility.Settings rewindAbility;
        public SlowEnemiesAbility.Settings slowEnemiesAbility;
        public FastBuildingsAbility.Settings fastBuildingsAbility;
        public FastRechargeUpgradeAbility.Settings fastRechargeUpgradeAbility;

        public AbilityRechargeTime abilityRechargeTime;

        public OneShotParticle exlposionPrefab;

        public LevelAbilitySoundPlayer.Settings levelAbilitySoundPlayer;

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
            Container.BindInstance(pathHistory);
            Container.BindInstance(abilityRechargeTime);
            Container.BindInstance(exlposionPrefab);
            Container.BindInstance(levelAbilitySoundPlayer);

            InstallAbilities();
        }

        private void InstallAbilities()
        {
            Container.BindInstance(rewindAbility);
            Container.BindInstance(slowEnemiesAbility);
            Container.BindInstance(fastBuildingsAbility);
            Container.BindInstance(fastRechargeUpgradeAbility);
        }
    }
}
