using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace MOATT.Installers
{
    using Levels.BillboardGroup;
    using Levels.Installers;
    using Levels.Billboards;

    [CreateAssetMenu(fileName = nameof(GameSettingsInstaller),
        menuName = "Installers/" + nameof(GameSettingsInstaller))]
    public class GameSettingsInstaller : ScriptableObjectInstaller
    {
        [SerializeField]
        private UnitHealthInstaller.GlobalSettings unitHealthInstallers;

        [SerializeField]
        private BillboardGroupInstaller.GlobalSettings billboardGroupInstaller;

        [SerializeField]
        private BillboardSource.Settings billboardSource;

        public override void InstallBindings()
        {
            Container.BindInstance(billboardSource);
            Container.BindInstance(billboardGroupInstaller);
            Container.BindInstance(unitHealthInstallers);
        }
    }
}
