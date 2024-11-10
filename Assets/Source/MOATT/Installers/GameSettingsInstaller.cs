using MOATT.Levels.Billboards;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace MOATT.Global.Installers
{
    using Levels.Installers;

    [CreateAssetMenu(fileName = nameof(GameSettingsInstaller),
        menuName = "Installers/" + nameof(GameSettingsInstaller))]
    public class GameSettingsInstaller : ScriptableObjectInstaller
    {
        [SerializeField]
        private LevelInstaller.GlobalSettings levelInstallers;

        [SerializeField]
        private BillboardSource.Settings billboardSource;

        public override void InstallBindings()
        {
            Container.BindInstance(levelInstallers);
            InstallBillboards();
        }

        private void InstallBillboards()
        {
            Container.BindInstance(billboardSource);
        }
    }
}
