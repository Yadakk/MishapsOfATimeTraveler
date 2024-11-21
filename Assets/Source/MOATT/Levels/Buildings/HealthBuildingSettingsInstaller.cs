using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace MOATT.Levels.Buildings
{
    using Health;

    [CreateAssetMenu(fileName = nameof(HealthBuildingSettingsInstaller),
        menuName = "Installers/Buildings/HealthBuildings/" + 
        nameof(HealthBuildingSettingsInstaller))]
    public class HealthBuildingSettingsInstaller : ScriptableObjectInstaller
    {
        [SerializeField]
        private HealthModel.Settings healthModel;

        public override void InstallBindings()
        {
            Container.BindInstance(healthModel);
        }
    }
}
