﻿using MOATT.Levels.Units.Damage;
using MOATT.Levels.Units.ReloadTime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MOATT.Levels.Buildings.Spikes
{
    [CreateAssetMenu(
    fileName = "SpikesInstaller",
    menuName = "Installers/Buildings/Spikes")]
    public class SpikesSettingsInstaller : BuildingSOI
    {
        public UnitDamage.Settings unitDamage;
        public UnitReloadTime.Settings reloadTime;

        public override void InstallBindings()
        {
            InstallSettings();
            Container.Install<SpikesInstaller>();
        }

        protected override void InstallSettings()
        {
            base.InstallSettings();

            Container.BindInstance(unitDamage);
            Container.BindInstance(reloadTime);
        }
    }
}
