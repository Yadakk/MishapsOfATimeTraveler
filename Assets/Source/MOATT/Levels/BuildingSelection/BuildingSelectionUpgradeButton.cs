using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace MOATT.Levels.BuildingSelection
{
    using BillboardGroup;

    public class BuildingSelectionUpgradeButton : MonoBehaviour
    {
        private BillboardGroupFacade billboardGroup;

        [Inject]
        public void Construct(BillboardGroupFacade billboardGroup)
        {
            this.billboardGroup = billboardGroup;
        }

        private void Start()
        {
            billboardGroup.AddBillboard(null, gameObject);
        }
    }
}
