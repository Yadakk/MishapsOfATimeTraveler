using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace MOATT.Levels.BillboardGroup
{
    using Billboards;

    public class BillboardGroupFacade : MonoBehaviour
    {
        private BillboardFacade.Factory billboardFactory;

        [Inject]
        public void Construct(BillboardFacade.Factory billboardFactory)
        {
            this.billboardFactory = billboardFactory;
        }

        public BillboardFacade AddBillboard(BillboardSource source, GameObject gui)
        {
            var billboard = billboardFactory.Create(source);
            Debug.Log(Time.frameCount);
            billboard.SetGUI(gui);
            return billboard;
        }
    }
}
