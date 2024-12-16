using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace MOATT.Abilities
{
    public class AbilityDurationVM : MonoBehaviour
    {
        [SerializeField] private Slider slider;

        private LevelAbility levelAbility;

        [Inject]
        public void Consruct(LevelAbility levelAbility)
        {
            this.levelAbility = levelAbility;
        }

        private void Start()
        {
            gameObject.SetActive(false);
            if (levelAbility.SelectedAbility.AbilityActiveDuration == null) return;
            levelAbility.SelectedAbility.AbilityActiveDuration.OnActiveChanged += ActiveChangedHandler;
        }

        private void OnDestroy()
        {
            if (levelAbility.SelectedAbility.AbilityActiveDuration == null) return;
            levelAbility.SelectedAbility.AbilityActiveDuration.OnActiveChanged -= ActiveChangedHandler;
        }

        private void Update()
        {
            slider.value = 1f -
                levelAbility.SelectedAbility.AbilityActiveDuration.ScalableTimer.Elapsed /
                levelAbility.SelectedAbility.AbilityActiveDuration.duration;
        }

        private void ActiveChangedHandler(bool value)
        {
            gameObject.SetActive(value);
        }
    }
}
