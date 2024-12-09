using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace MOATT.Levels.BuildingPlacement
{
    using Buildings;
    using Economics;
    using System;
    using Tooltips;

    public class BuildingPlacementSelectorVM : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField]
        private BuildingFacade buildingPrefab;

        [SerializeField]
        private float rechargeTime = 1f;

        private BuildingPlacementBuildingInfo buildingInfo;

        private BuildingPlacementSelector selector;
        private BuildingFacade.Factory buildingFactory;
        private PlayerResources playerResources;
        private Tooltip tooltip;

        private void Awake()
        {
            buildingInfo.rechargeTime = rechargeTime;
            buildingInfo.prototype = buildingFactory.Create(buildingPrefab, null);
            buildingInfo.prototype.gameObject.SetActive(false);
        }

        private void Update()
        {
            buildingInfo.Tick();
        }

        [Inject]
        public void Construct(BuildingPlacementSelector selector, BuildingFacade.Factory buildingFactory, PlayerResources playerResources, Tooltip tooltip, BuildingPlacementBuildingInfo buildingInfo)
        {
            this.selector = selector;
            this.buildingFactory = buildingFactory;
            this.playerResources = playerResources;
            this.tooltip = tooltip;
            this.buildingInfo = buildingInfo;
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            tooltip.DisplayAtCursor(buildingInfo.prototype.ToString());
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            tooltip.Hide();
        }

        public void Select()
        {
            bool isCharged = buildingInfo.IsCharged;
            Debug.Log(isCharged);
            bool isDifferentBuilding = selector.BuildingInfo != buildingInfo;
            bool isAffordable = playerResources.NutsAndBolts >= buildingInfo.prototype.NutsAndBoltsCost;

            if (isDifferentBuilding && isAffordable && isCharged)
                selector.SelectBuilding(buildingInfo);
            else
                selector.SelectBuilding(null);
        }
    }
}