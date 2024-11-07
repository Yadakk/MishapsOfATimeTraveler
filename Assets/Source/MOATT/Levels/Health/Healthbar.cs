using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MOATT.Levels.Health
{
    public class Healthbar : MonoBehaviour
    {
        public IHealth iHealth;

        private Slider slider;

        private void Awake()
        {
            slider = GetComponentInChildren<Slider>();
        }

        private void Update()
        {
            slider.maxValue = iHealth.MaxHealth;
            slider.value = iHealth.CurrentHealth;
        }
    }
}
