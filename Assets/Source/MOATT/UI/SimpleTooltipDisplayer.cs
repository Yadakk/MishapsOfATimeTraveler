using MOATT.Tooltips;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace MOATT.UI
{
    public class SimpleTooltipDisplayer : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField, TextArea] private string text;

        private Tooltip tooltip;

        [Inject]
        public void Construct(Tooltip tooltip)
        {
            this.tooltip = tooltip;
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            tooltip.DisplayAtCursor(text);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            tooltip.Hide();
        }
    }
}
