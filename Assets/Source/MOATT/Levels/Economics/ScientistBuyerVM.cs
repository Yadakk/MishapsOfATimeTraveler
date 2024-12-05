using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace MOATT.Levels.Economics
{
    using Tooltips;

    public class ScientistBuyerVM : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        private Settings settings;
        private PlayerResources resources;
        private Tooltip tooltip;

        [Inject]
        public void Construct(Settings settings, PlayerResources resources = null, Tooltip tooltip = null)
        {
            this.settings = settings;
            this.resources = resources;
            this.tooltip = tooltip;
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            tooltip.DisplayAtCursor($"Hire 1 scientist at cost of {settings.scientistCost} Nuts and Bolts");
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            tooltip.Hide();
        }

        public void BuyScientist()
        {
            if (resources.NutsAndBolts < settings.scientistCost) return;
            resources.NutsAndBolts -= settings.scientistCost;
            resources.Scientists += 1;
        }

        [Serializable]
        public class Settings
        {
            public int scientistCost = 300;
        }
    }
}
