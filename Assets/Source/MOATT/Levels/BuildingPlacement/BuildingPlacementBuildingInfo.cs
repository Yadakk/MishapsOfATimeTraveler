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
    using System.Linq;
    using System.Text;

    public class BuildingPlacementBuildingInfo : ITickable
    {
        private readonly Dictionary<object, float> multipliers = new();

        public BuildingFacade prototype;
        public float rechargeTime = 1f;

        private bool isCharged = true;

        private readonly ScalableTimer timer;

        public BuildingPlacementBuildingInfo(ScalableTimer timer)
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

        public ScalableTimer Timer => timer;

        public void Tick()
        {
            if (timer.Elapsed < rechargeTime) return;
            IsCharged = true;
        }

        public void AddMultiplier(object obj, float value)
        {
            if (multipliers.ContainsKey(obj)) return;
            multipliers.Add(obj, value);
            RecalculateMultiplier();
        }

        public void RemoveMultiplier(object obj)
        {
            if (!multipliers.ContainsKey(obj)) return;
            multipliers.Remove(obj);
            RecalculateMultiplier();
        }

        public override string ToString()
        {
            StringBuilder sb = new();
            sb.Append(prototype.ToString());
            sb.AppendLine($"Can be placed every {rechargeTime} seconds");
            return sb.ToString();
        }

        private void RecalculateMultiplier()
        {
            float totalMultiplier = 1f;

            for (int i = 0; i < multipliers.Count; i++)
            {
                totalMultiplier *= multipliers.ElementAt(i).Value;
            }

            timer.timeScale = totalMultiplier;
        }
    }
}
