using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace MOATT.Abilities
{
    public class AbilityFill : MonoBehaviour
    {
        [SerializeField] private Image image;

        private AbilityRecharger abilityRecharger;
        private AbilityRechargeTime abilityRechargeTime;

        [Inject]
        public void Construct(AbilityRecharger abilityRecharger, AbilityRechargeTime abilityRechargeTime)
        {
            this.abilityRecharger = abilityRecharger;
            this.abilityRechargeTime = abilityRechargeTime;
        }

        private void Update()
        {
            image.fillAmount = 1f - abilityRecharger.ScalableTimer.Elapsed / abilityRechargeTime.value;
        }
    }
}
