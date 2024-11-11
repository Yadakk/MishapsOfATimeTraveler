using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace MOATT.Levels.Billboards
{
    public class BillboardInstaller : MonoInstaller
    {
        private BillboardSource billboardSource;

        [Inject]
        public void Construct(BillboardSource billboardSource)
        {
            this.billboardSource = billboardSource;
        }

        public override void InstallBindings()
        {
            Container.BindInstance(billboardSource).AsSingle();
            Container.BindInterfacesAndSelfTo<BillboardPositioner>().AsSingle();
        }
    }
}
