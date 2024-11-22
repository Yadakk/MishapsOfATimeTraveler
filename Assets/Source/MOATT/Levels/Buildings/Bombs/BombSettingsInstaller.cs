using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MOATT.Levels.Buildings.Bombs
{
    [CreateAssetMenu(fileName = nameof(BombSettingsInstaller),
        menuName = "Installers/Buildings/" +
        nameof(BombSettingsInstaller))]
    public class BombSettingsInstaller : BuildingSettingsInstaller
    {
        public override void InstallBindings()
        {
            base.InstallBindings();

            //TODO: Install settings
        }
    }
}
