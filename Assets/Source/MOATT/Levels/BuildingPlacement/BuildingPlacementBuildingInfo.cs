using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using TimeTimers;

namespace MOATT.Levels.BuildingPlacement
{
    using Buildings;

    public class BuildingPlacementBuildingInfo : ITickable
    {
        public BuildingFacade prototype;
        public float rechargeTime = 1f;

        private bool isCharged = true;

        private readonly Timer timer;

        public BuildingPlacementBuildingInfo(Timer timer)
        {
            this.timer = timer;
        }

        public bool IsCharged
        {
            get => isCharged;
            set
            {
                isCharged = value;
                if (!isCharged) timer.Reset();
            }
        }

        public void Tick()
        {
            if (timer.Elapsed > rechargeTime) IsCharged = true;
        }
    }
}
