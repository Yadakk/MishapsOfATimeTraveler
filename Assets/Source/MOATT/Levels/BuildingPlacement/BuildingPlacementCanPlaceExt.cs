using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace MOATT.Levels.BuildingPlacement
{
    using Buildings;
    using Tiles;

    public static class BuildingPlacementCanPlaceExt
    {
        public static bool CanBePlacedOn(this BuildingFacade building, TileFacade tile)
        {
            if (!CanBePlaced(building, tile)) return false;
            return DoTypesMatch(building, tile);
        }

        public static BuildingPlacementHologram.DisplayArgs GetHologramArgs(
            this BuildingFacade building, TileFacade tile)
        {
            bool isDisplayed = CanBePlaced(building, tile);

            bool isAcceptable = isDisplayed && DoTypesMatch(building, tile);

            return new()
            {
                IsDisplayed = isDisplayed,
                IsAcceptable = isAcceptable,
            };
        }

        private static bool CanBePlaced(BuildingFacade building, TileFacade tile)
        {
            if (building == null) return false;
            if (tile == null) return false;

            if (tile.CurrentBuilding != null) return false;
            return true;
        }

        private static bool DoTypesMatch(BuildingFacade building, TileFacade tile)
        {
            return building.CanBePlacedOn.HasFlag(tile.TypeForBuildings);
        }
    }
}
