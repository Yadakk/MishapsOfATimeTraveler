using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MOATT.Levels.Buildings.HealthBuildings
{
    using Health;

    [CreateAssetMenu(fileName = nameof(HealthBuildingSettingsInstaller),
        menuName = "Installers/Buildings/HealthBuildings/" + 
        nameof(HealthBuildingSettingsInstaller))]
    public class HealthBuildingSettingsInstaller : BuildingSettingsInstaller
    {
        public HealthModel.Settings healthModel;

        public override void InstallBindings()
        {
            base.InstallBindings();

            Container.BindInstance(healthModel);
        }
    }
}
