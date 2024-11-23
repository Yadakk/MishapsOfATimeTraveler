using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace MOATT.Levels.UnitRange
{
    public class UnitRangeInstaller : Installer
    {
        public override void InstallBindings()
        {
            Container.Bind<UnitRange>().AsSingle();
        }
    }
}
