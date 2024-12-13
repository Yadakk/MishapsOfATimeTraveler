using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Zenject;

namespace MOATT.Levels.BuildingPlacement
{
    using Buildings;
    using Economics;
    using System;
    using Tooltips;
    using PrototypePool;

    public class BuildingPlacementSelectorVM : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField]
        private BuildingFacade buildingPrefab;

        [SerializeField]
        private float rechargeTime = 1f;

        [SerializeField]
        private Image chargeFill;

        private BuildingPlacementBuildingInfo buildingInfo;

        private BuildingPlacementSelector selector;
        private PlayerResources playerResources;
        private Tooltip tooltip;
        private BuildingPrototypePool prototypePool;

        private void Awake()
        {
            buildingInfo.rechargeTime = rechargeTime;
            buildingInfo.prototype = prototypePool.GetPrototype(buildingPrefab);
        }

        private void Update()
        {
            chargeFill.fillAmount = buildingInfo.IsCharged ? 0f : 1f - buildingInfo.Timer.Elapsed / buildingInfo.rechargeTime;
        }

        [Inject]
        public void Construct(BuildingPlacementSelector selector, PlayerResources playerResources, Tooltip tooltip, BuildingPlacementBuildingInfo buildingInfo, BuildingPrototypePool prototypePool)
        {
            this.selector = selector;
            this.playerResources = playerResources;
            this.tooltip = tooltip;
            this.buildingInfo = buildingInfo;
            this.prototypePool = prototypePool;
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            tooltip.DisplayAtCursor(buildingInfo.ToString());
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            tooltip.Hide();
        }

        public void Select()
        {
            bool isCharged = buildingInfo.IsCharged;
            bool isDifferentBuilding = selector.BuildingInfo != buildingInfo;
            bool isAffordable = playerResources.NutsAndBolts >= buildingInfo.prototype.NutsAndBoltsCost;

            if (isDifferentBuilding && isAffordable && isCharged)
                selector.SelectBuilding(buildingInfo);
            else
                selector.SelectBuilding(null);
        }
    }
}