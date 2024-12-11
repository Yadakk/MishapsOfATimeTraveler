using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace MOATT.Levels.BuildingSelection
{
    public class BuildingSelectionUpgradeButtonDisplayer : IInitializable, IDisposable
    {
        private readonly BuildingSelectionUpgradeButton button;
        private readonly BuildingSelectionSelector selector;

        public BuildingSelectionUpgradeButtonDisplayer(BuildingSelectionUpgradeButton button, BuildingSelectionSelector selector)
        {
            this.button = button;
            this.selector = selector;
        }

        public void Initialize()
        {
            selector.OnBuildingSelected += UpdateDisplayer;
        }

        public void Dispose()
        {
            selector.OnBuildingSelected -= UpdateDisplayer;
        }

        private void UpdateDisplayer()
        {
            button.gameObject.SetActive(CanShowButton());
            button.SetBuilding(selector.SelectedBuilding);
        }

        private bool CanShowButton()
        {
            if (selector.SelectedBuilding == null) return false;
            if (selector.SelectedBuilding.BuildingUpgrader == null) return false;
            if (selector.SelectedBuilding.BuildingUpgrader.UpgradedPrefab == null) return false;
            return true;
        }
    }
}
