using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MOATT.Levels.BuildingPlacement
{
    using UnitRange;
    using Buildings;
    using TilemapSizeMultipliers;

    public class BuildingPlacementRange
    {
        private readonly UnitRangeHologram hologram;
        private readonly TilemapSizeMultiplier tilemapSizeMultiplier;

        public BuildingPlacementRange(TilemapSizeMultiplier tilemapSizeMultiplier, UnitRangeHologram hologram = null)
        {
            this.tilemapSizeMultiplier = tilemapSizeMultiplier;
            this.hologram = hologram;
        }

        public void DisplayRange(BuildingFacade buildingPrefab, Vector3 newPosition)
        {
            hologram.SetActive(TryDisplayRange(buildingPrefab, newPosition));
        }

        private bool TryDisplayRange(BuildingFacade buildingPrefab, Vector3 newPosition)
        {
            var unitRangeSOI = buildingPrefab.GetSOInstaller<UnitRangeSOInstaller>();
            if (unitRangeSOI == null) return false;
            hologram.DisplayRange(tilemapSizeMultiplier.Multiply(unitRangeSOI.unitRange.rangeTiles));
            hologram.transform.position = newPosition;
            return true;
        }
    }
}
