using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using TimeTimers;
using Cannedenuum.ZenjectUtils.MonoInterfaces;
using MOATT.Levels.Units.ReloadTime;

namespace MOATT.Levels.Buildings.Bombs
{
    public class BombTimer : IUpdatable
    {
        private readonly Timer timer;
        private readonly UnitReloadTime reloadTime;
        private readonly BombExploder exploder;

        public BombTimer(Timer timer, UnitReloadTime reloadTime, BombExploder exploder)
        {
            this.timer = timer;
            this.reloadTime = reloadTime;
            this.exploder = exploder;
        }

        public void Update()
        {
            if (timer.Elapsed >= reloadTime.Value)
                exploder.Explode();
        }
    }
}
