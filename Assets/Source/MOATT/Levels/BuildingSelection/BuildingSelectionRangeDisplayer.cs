using MOATT.Levels.Units.Range;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace MOATT.Levels.BuildingSelection
{
    public class BuildingSelectionRangeDisplayer : IInitializable, IDisposable
    {
        private readonly BuildingSelectionSelector selector;
        private readonly UnitRangeHologram unitRangeHologram;

        public BuildingSelectionRangeDisplayer(BuildingSelectionSelector selector, UnitRangeHologram unitRangeHologram)
        {
            this.selector = selector;
            this.unitRangeHologram = unitRangeHologram;
        }

        public void Initialize()
        {
            selector.OnBuildingSelected += SelectedHandler;
        }

        public void Dispose()
        {
            selector.OnBuildingSelected -= SelectedHandler;
        }

        private void SelectedHandler()
        {
            if (selector.SelectedBuilding == null || selector.SelectedBuilding.BuildingRange == null)
            {
                unitRangeHologram.SetActive(false);
            }
            else
            {
                unitRangeHologram.transform.position = selector.SelectedBuilding.transform.position;
                unitRangeHologram.DisplayRange(selector.SelectedBuilding.BuildingRange.Range);
            }
        }
    }
}
