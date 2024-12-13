using MOATT.Tooltips;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace MOATT.Levels.Economics
{
    public class ScientistRechargeMultiplierVM : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        private ScientistRechargeMultiplier scientistRechargeMultiplier;
        private Tooltip tooltip;

        [Inject] 
        public void Construct(ScientistRechargeMultiplier scientistRechargeMultiplier, Tooltip tooltip)
        {
            this.scientistRechargeMultiplier = scientistRechargeMultiplier;
            this.tooltip = tooltip;
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            tooltip.DisplayAtCursor(GetText(scientistRechargeMultiplier.Value));
            scientistRechargeMultiplier.valueWatcher.OnValueChangedNewValue += UpdateText;
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            tooltip.Hide();
            scientistRechargeMultiplier.valueWatcher.OnValueChangedNewValue -= UpdateText;
        }

        private void UpdateText(float newMultiplier)
        {
            tooltip.SetText(GetText(newMultiplier));
        }

        private string GetText(float multiplier)
        {
            return "Currently your idle scientists increase building and ability recharge speed by " +
                string.Format($"{{0:P0}}.", multiplier - 1f);
        }
    }
}
