using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace MOATT.Levels.UnitHealth
{
    using Health;

    [CreateAssetMenu(
        fileName = "UnitHealthInstaller",
        menuName = "Installers/UnitHealth")]
    public class UnitHealthSOInstaller : ScriptableObjectInstaller
    {
        public HealthModel.Settings healthModel;

        public override void InstallBindings()
        {
            InstallSettings();
            Container.Install<UnitHealthInstaller>();
        }

        protected virtual void InstallSettings()
        {
            Container.BindInstance(healthModel);
        }
    }
}
