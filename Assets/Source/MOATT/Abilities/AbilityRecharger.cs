using MOATT.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace MOATT.Abilities
{
    public class AbilityRecharger : ITickable
    {
        private readonly ScalableTimer scalableTimer;
        private readonly AbilityRechargeTime rechargeTime;
        private bool isReady = false;

        public AbilityRecharger(ScalableTimer scalableTimer, AbilityRechargeTime rechargeTime)
        {
            this.scalableTimer = scalableTimer;
            this.rechargeTime = rechargeTime;
        }

        public bool IsReady
        {
            get => isReady;
            set
            {
                isReady = value;
                if (!isReady) scalableTimer.Reset();
            }
        }

        public ScalableTimer ScalableTimer => scalableTimer;

        public void Tick()
        {
            if (scalableTimer.Elapsed < rechargeTime.value) return;
            IsReady = true;
        }
    }
}
