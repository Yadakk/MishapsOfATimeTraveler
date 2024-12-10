using MOATT.Levels.Buildings;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace MOATT.Levels.BuildingSelection
{
    public class BuildingSelectionOutlineColorizer : IInitializable, IDisposable
    {
        private readonly BuildingSelectionHoverer hoverer;
        private readonly BuildingSelectionSelector selector;
        private readonly Settings settings;

        private BuildingFacade previouslyOutlined;

        public BuildingSelectionOutlineColorizer(BuildingSelectionHoverer hoverer, BuildingSelectionSelector selector, Settings settings)
        {
            this.hoverer = hoverer;
            this.selector = selector;
            this.settings = settings;
        }

        public void Initialize()
        {
            hoverer.OnBuildingHovered += UpdateOutline;
            selector.OnBuildingSelected += UpdateOutline;
        }

        public void Dispose()
        {
            hoverer.OnBuildingHovered -= UpdateOutline;
            selector.OnBuildingSelected -= UpdateOutline;
        }

        private void UpdateOutline()
        {
            if (previouslyOutlined != null) previouslyOutlined.Outline.enabled = false;
            SelectOutlineColor();
        }

        private void SelectOutlineColor()
        {
            if (selector.SelectedBuilding != null)
            {
                selector.SelectedBuilding.Outline.enabled = true;
                selector.SelectedBuilding.Outline.OutlineColor = settings.selectedColor;
                previouslyOutlined = selector.SelectedBuilding;
                return;
            }

            if (hoverer.HoveredBuilding != null)
            {
                hoverer.HoveredBuilding.Outline.enabled = true;
                hoverer.HoveredBuilding.Outline.OutlineColor = settings.hoveredColor;
                previouslyOutlined = hoverer.HoveredBuilding;
                return;
            }
        }

        [Serializable]
        public class Settings
        {
            public Color hoveredColor = Color.white;
            public Color selectedColor = Color.white;
        }
    }
}