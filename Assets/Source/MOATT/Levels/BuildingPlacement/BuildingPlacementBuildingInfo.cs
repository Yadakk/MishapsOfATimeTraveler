using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using TimeTimers;

namespace MOATT.Levels.BuildingPlacement
{
    using Buildings;
    using System.Text;

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

        public Timer Timer => timer;

        public void Tick()
        {
            if (timer.Elapsed > rechargeTime) IsCharged = true;
        }
        
        public override string ToString()
        {
            StringBuilder sb = new();
            sb.Append(prototype.ToString());
            sb.AppendLine($"Can be placed every {rechargeTime} seconds");
            return sb.ToString();
        }
    }
}
