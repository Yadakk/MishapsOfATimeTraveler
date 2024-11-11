using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace MOATT.Levels.Billboards
{
    public class BillboardInstaller : MonoInstaller
    {
        private BillboardSource source;

        [Inject]
        public void Construct(BillboardSource source)
        {
            this.source = source;
        }

        public override void InstallBindings()
        {
            Container.BindInstance(source);

            Container.BindInterfacesAndSelfTo<BillboardPositioner>().AsSingle();
        }
    }
}
