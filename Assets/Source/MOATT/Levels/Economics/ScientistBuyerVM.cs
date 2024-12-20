﻿using System;
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

        public event Action OnScientistHired;

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
            if (resources.IdleScientists + resources.BusyScientists + 1 > resources.MaxScientists) return;
            resources.NutsAndBolts -= settings.scientistCost;
            resources.IdleScientists += 1;
            OnScientistHired?.Invoke();
        }

        [Serializable]
        public class Settings
        {
            public int scientistCost = 300;
        }
    }
}
