using MOATT.Tooltips;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Zenject;

namespace MOATT.Abilities
{
    public class AbilityToggle : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField] private Toggle toggle;
        [SerializeField] private AbilityType abilityType;

        private Tooltip tooltip;
        private SelectedAbilityType selectedAbility;
        private AbilityDescriptionDictionary descriptionDictionary;
        private object abilityDescription;

        private void Start()
        {
            if (selectedAbility.ability == abilityType) toggle.isOn = true;
            toggle.onValueChanged.AddListener(ToggleValueChangedHandler);
            abilityDescription = descriptionDictionary.Dictionary.GetValueOrDefault(abilityType);
        }

        [Inject]
        public void Construct(SelectedAbilityType selectedAbility, Tooltip tooltip, AbilityDescriptionDictionary descriptionDictionary)
        {
            this.selectedAbility = selectedAbility;
            this.tooltip = tooltip;
            this.descriptionDictionary = descriptionDictionary;
        }

        private void ToggleValueChangedHandler(bool value)
        {
            if (value) selectedAbility.ability = abilityType;
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            tooltip.DisplayAtCursor(abilityDescription.ToString());
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            tooltip.Hide();
        }
    }
}
