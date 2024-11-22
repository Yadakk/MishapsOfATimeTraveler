using MOATT.Levels.Buildings.HealthBuildings;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace MOATT.Levels.Buildings
{
    [CreateAssetMenu(fileName = nameof(BuildingSettingsInstaller),
    menuName = "Installers/Buildings/" +
    nameof(BuildingSettingsInstaller))]
    public class BuildingSettingsInstaller : ScriptableObjectInstaller
    {
        public BuildingFacade.Settings buildingFacade;

        public override void InstallBindings()
        {
            Container.BindInstance(buildingFacade);
        }
    }
}
