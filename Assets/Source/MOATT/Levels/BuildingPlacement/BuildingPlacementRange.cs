using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MOATT.Levels.BuildingPlacement
{
    using Units.Range;
    using Buildings;

    public class BuildingPlacementRange
    {
        private readonly UnitRangeHologram hologram;

        public BuildingPlacementRange(UnitRangeHologram hologram = null)
        {
            this.hologram = hologram;
        }

        public void DisplayRange(BuildingFacade buildingPrototype, Vector3 newPosition)
        {
            hologram.SetActive(TryDisplayRange(buildingPrototype, newPosition));
        }

        private bool TryDisplayRange(BuildingFacade buildingPrototype, Vector3 newPosition)
        {
            var unitRange = buildingPrototype.BuildingRange;
            if (unitRange == null) return false;
            hologram.DisplayRange(unitRange.Range);
            hologram.transform.position = newPosition;
            return true;
        }
    }
}
