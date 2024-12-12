using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace MOATT.Levels.BuildingSelection
{
    using BillboardGroup;
    using MOATT.Levels.Billboards;
    using MOATT.Levels.Buildings;
    using MOATT.Tooltips;
    using UnityEngine.EventSystems;

    public class BuildingSelectionUpgradeButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        private BillboardGroupFacade billboardGroup;
        private BuildingFacade building;
        private BillboardFacade billboard;
        private Tooltip tooltip;

        public BuildingFacade Building { get => building; private set => building = value; }

        [Inject]
        public void Construct(BillboardGroupFacade billboardGroup, Tooltip tooltip)
        {
            this.billboardGroup = billboardGroup;
            this.tooltip = tooltip;
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            tooltip.DisplayAtCursor(Building.BuildingUpgrader.ToString());
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            tooltip.Hide();
        }

        public void SetBuilding(BuildingFacade newBuilding)
        {
            Building = newBuilding;
            billboard.SetSource(Building != null ? Building.BillboardSource : null);
        }

        public void UpgradeBuilding()
        {
            Building.BuildingUpgrader.TryUpgrade();
        }

        private void Start()
        {
            billboard = billboardGroup.AddBillboard(null, gameObject);
            gameObject.SetActive(false);
        }
    }
}
