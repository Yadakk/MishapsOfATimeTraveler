using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace MOATT.Levels.BuildingSelection
{
    using BillboardGroup;
    using MOATT.Levels.Billboards;
    using MOATT.Levels.Buildings;

    public class BuildingSelectionUpgradeButton : MonoBehaviour
    {
        private BillboardGroupFacade billboardGroup;
        private BuildingFacade building;
        private BillboardFacade billboard;

        [Inject]
        public void Construct(BillboardGroupFacade billboardGroup)
        {
            this.billboardGroup = billboardGroup;
        }

        public void SetBuilding(BuildingFacade newBuilding)
        {
            building = newBuilding;
            billboard.SetSource(building != null ? building.BillboardSource : null);
        }

        private void Start()
        {
            billboard = billboardGroup.AddBillboard(null, gameObject);
            gameObject.SetActive(false);
        }
    }
}
