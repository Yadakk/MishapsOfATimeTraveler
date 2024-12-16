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

        private BuildingPlacementSelector selector;
        private PlayerResources playerResources;
        private Tooltip tooltip;
        private BuildingPrototypePool prototypePool;

        public BuildingPlacementBuildingInfo BuildingInfo { get; private set; }

        private void Awake()
        {
            BuildingInfo.rechargeTime = rechargeTime;
            BuildingInfo.prototype = prototypePool.GetPrototype(buildingPrefab);
        }

        private void Update()
        {
            chargeFill.fillAmount = BuildingInfo.IsCharged ? 0f : 1f - BuildingInfo.Timer.Elapsed / BuildingInfo.rechargeTime;
        }

        [Inject]
        public void Construct(BuildingPlacementSelector selector, PlayerResources playerResources, Tooltip tooltip, BuildingPlacementBuildingInfo buildingInfo, BuildingPrototypePool prototypePool)
        {
            this.selector = selector;
            this.playerResources = playerResources;
            this.tooltip = tooltip;
            this.BuildingInfo = buildingInfo;
            this.prototypePool = prototypePool;
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            tooltip.DisplayAtCursor(BuildingInfo.ToString());
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            tooltip.Hide();
        }

        public void Select()
        {
            bool isCharged = BuildingInfo.IsCharged;
            bool isDifferentBuilding = selector.BuildingInfo != BuildingInfo;
            bool isAffordable = playerResources.NutsAndBolts >= BuildingInfo.prototype.NutsAndBoltsCost;

            if (isDifferentBuilding && isAffordable && isCharged)
                selector.SelectBuilding(BuildingInfo);
            else
                selector.SelectBuilding(null);
        }
    }
}