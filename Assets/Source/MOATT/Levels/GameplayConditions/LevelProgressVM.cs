using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace MOATT.Levels.GameplayConditions
{
    public class LevelProgressVM : MonoBehaviour
    {
        [SerializeField] private Slider slider;

        private LevelProgress levelProgress;

        [Inject]
        public void Construct(LevelProgress levelProgress)
        {
            this.levelProgress = levelProgress;
        }

        private void Update()
        {
            slider.value = levelProgress.Progress;
        }
    }
}
