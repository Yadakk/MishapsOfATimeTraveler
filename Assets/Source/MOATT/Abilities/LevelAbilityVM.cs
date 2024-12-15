using MOATT.Tooltips;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace MOATT.Abilities
{
    public class LevelAbilityVM : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        private LevelAbility levelAbility;
        private Tooltip tooltip;

        [Inject]
        public void Construct(LevelAbility levelAbility, Tooltip tooltip)
        {
            this.levelAbility = levelAbility;
            this.tooltip = tooltip;
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            tooltip.DisplayAtCursor(levelAbility.SelectedAbility.ToString());
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            tooltip.Hide();
        }

        public void ActivateAbility()
        {
            levelAbility.Activate();
        }
    }
}
