using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace MOATT.Levels.BuildingPlacement
{
    using Buildings;
    using MOATT.Levels.Economics;
    using MOATT.Utils;
    using System.Text;

    public class BuildingPlacementBuildingInfo : IInitializable, ITickable, IDisposable
    {
        public BuildingFacade prototype;
        public float rechargeTime = 1f;

        private bool isCharged = true;

        private readonly ScalableTimer timer;
        private readonly ScientistRechargeMultiplier scientistRechargeMultiplier;

        public BuildingPlacementBuildingInfo(ScalableTimer timer, ScientistRechargeMultiplier scientistRechargeMultiplier)
        {
            this.timer = timer;
            this.scientistRechargeMultiplier = scientistRechargeMultiplier;
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

        public ScalableTimer Timer => timer;

        public void Initialize()
        {
            scientistRechargeMultiplier.valueWatcher.OnValueChangedNewValue += SetTimerScale;
        }

        public void Tick()
        {
            if (timer.Elapsed < rechargeTime) return;
            IsCharged = true;
        }

        public void Dispose()
        {
            scientistRechargeMultiplier.valueWatcher.OnValueChangedNewValue -= SetTimerScale;
        }

        public override string ToString()
        {
            StringBuilder sb = new();
            sb.Append(prototype.ToString());
            sb.AppendLine($"Can be placed every {rechargeTime} seconds");
            return sb.ToString();
        }

        private void SetTimerScale(float timeScale)
        {
            timer.timeScale = timeScale;
            Debug.Log(timer.timeScale);
        }
    }
}
