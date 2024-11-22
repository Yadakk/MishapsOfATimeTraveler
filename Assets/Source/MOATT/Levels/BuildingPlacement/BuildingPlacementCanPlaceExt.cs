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
            if (building == null) return false;
            if (tile == null) return false;

            return DoTypesMatch(building, tile);
        }

        public static BuildingPlacementHologram.DisplayArgs GetHologramArgs(
            this BuildingFacade building, TileFacade tile)
        {
            bool isDisplayed = true;

            if (building == null) isDisplayed = false;
            if (tile == null) isDisplayed = false;

            bool isAcceptable = isDisplayed && DoTypesMatch(building, tile);

            return new()
            {
                IsDisplayed = isDisplayed,
                IsAcceptable = isAcceptable,
            };
        }

        private static bool DoTypesMatch(BuildingFacade building, TileFacade tile)
        {
            return building.GetSettingsInstaller().buildingFacade.canBePlacedOn.
                HasFlag(tile.TypeForBuildings);
        }
    }
}
