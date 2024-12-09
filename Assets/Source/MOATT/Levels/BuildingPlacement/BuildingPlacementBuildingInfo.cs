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
        [NonSerialized]
        public BuildingFacade prototype;

        [NonSerialized]
        public float RechargeTime = 1f;

        private bool isReady = true;

        private readonly Timer timer;

        public BuildingPlacementBuildingInfo(Timer timer)
        {
            this.timer = timer;
        }

        public bool IsReady
        {
            get => isReady;
            private set
            {
                isReady = value;
                if (!isReady) timer.Reset();
            }
        }

        public void Tick()
        {
            IsReady = timer.Elapsed > RechargeTime;
        }
    }
}
