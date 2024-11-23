using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace MOATT.Levels.UnitRange
{
    [CreateAssetMenu(
        fileName = "UnitRangeInstaller",
        menuName = "Installers/UnitRange")]
    public class UnitRangeSOInstaller : ScriptableObjectInstaller
    {
        public UnitRange.Settings unitRange;

        public override void InstallBindings()
        {
            InstallSettings();
            Container.Install<UnitRangeInstaller>();
        }

        protected virtual void InstallSettings()
        {
            Container.BindInstance(unitRange);
        }
    }
}
