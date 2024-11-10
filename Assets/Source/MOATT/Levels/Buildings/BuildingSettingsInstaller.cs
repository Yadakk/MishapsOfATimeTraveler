using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace MOATT.Levels.Buildings
{
    using Health;

    [CreateAssetMenu(fileName = nameof(BuildingSettingsInstaller),
        menuName = "Installers/" + nameof(BuildingSettingsInstaller))]
    public class BuildingSettingsInstaller : ScriptableObjectInstaller
    {
        [SerializeField]
        private HealthModel.Settings healthModel;

        public override void InstallBindings()
        {
            Container.BindInstance(healthModel);
        }
    }
}
