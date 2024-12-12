using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace MOATT.Levels.BuildingSelection
{
    public class BuildingSelectionUpgradeProgressDisplayer : MonoBehaviour
    {
        private BuildingSelectionUpgradeButton upgradeButton;
        private Image image;

        [Inject]
        public void Construct(BuildingSelectionUpgradeButton upgradeButton)
        {
            this.upgradeButton = upgradeButton;
        }

        private void Awake()
        {
            image = GetComponent<Image>();
        }

        private void Update()
        {
            image.fillAmount = upgradeButton.Building.BuildingUpgrader.UpgradeProgress;
        }
    }
}
