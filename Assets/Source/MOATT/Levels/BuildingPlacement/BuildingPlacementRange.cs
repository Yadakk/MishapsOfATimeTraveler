using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MOATT.Levels.BuildingPlacement
{
    using UnitRange;
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
            var unitRangeSOI = buildingPrototype.BuildingRange;
            if (unitRangeSOI == null) return false;
            hologram.DisplayRange(unitRangeSOI.Range);
            hologram.transform.position = newPosition;
            return true;
        }
    }
}
