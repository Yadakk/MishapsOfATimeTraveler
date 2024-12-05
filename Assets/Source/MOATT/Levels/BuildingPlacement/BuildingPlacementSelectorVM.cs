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

        private BuildingPlacementSelector selector;
        private BuildingFacade.Factory buildingFactory;
        private PlayerResources playerResources;
        private Tooltip tooltip;

        private BuildingFacade buildingPrototype;

        private void Awake()
        {
            buildingPrototype = buildingFactory.Create(buildingPrefab, null);
            buildingPrototype.gameObject.SetActive(false);
        }

        [Inject]
        public void Construct(BuildingPlacementSelector selector, BuildingFacade.Factory buildingFactory, PlayerResources playerResources, Tooltip tooltip)
        {
            this.selector = selector;
            this.buildingFactory = buildingFactory;
            this.playerResources = playerResources;
            this.tooltip = tooltip;
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            tooltip.DisplayAtCursor(buildingPrototype.ToString());
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            tooltip.Hide();
        }

        public void Select()
        {
            bool isDifferentBuilding = selector.BuildingPrototype != buildingPrototype;
            bool isAffordable = playerResources.NutsAndBolts >= buildingPrototype.NutsAndBoltsCost;

            if (isDifferentBuilding && isAffordable)
                selector.SelectBuilding(buildingPrototype);
            else
                selector.SelectBuilding(null);
        }
    }
}