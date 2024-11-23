using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace MOATT.Levels.BuildingPlacement
{
    using UnitRange;
    using Buildings;
    using MOATT.Levels.Range;

    public class BuildingPlacementRange
    {
        private readonly UnitRangeHologram hologram;
        private readonly Tilemap tilemap;

        public BuildingPlacementRange(Tilemap tilemap, UnitRangeHologram hologram = null)
        {
            this.tilemap = tilemap;
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
            hologram.DisplayRange(UnitTilemapRangeGetter.GetRange(tilemap, unitRangeSOI.unitRange.rangeTiles));
            hologram.transform.position = newPosition;
            return true;
        }
    }
}
