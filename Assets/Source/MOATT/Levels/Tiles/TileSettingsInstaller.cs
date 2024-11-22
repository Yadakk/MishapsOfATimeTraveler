using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace MOATT.Levels.Tiles
{
    [CreateAssetMenu(fileName = nameof(TileSettingsInstaller),
        menuName = "Installers/" + nameof(TileSettingsInstaller))]
    public class TileSettingsInstaller : ScriptableObjectInstaller
    {
        public TileCell.Settings tileCell;
        public TileBuilding.Settings tileBuilding;

        public override void InstallBindings()
        {
            Container.BindInstance(tileCell);
            Container.BindInstance(tileBuilding);
        }
    }
}