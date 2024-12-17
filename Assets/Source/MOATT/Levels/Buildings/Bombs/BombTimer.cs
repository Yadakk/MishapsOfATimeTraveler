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
        private readonly Renderer[] renderers;

        public BombTimer(Timer timer, UnitReloadTime reloadTime, BombExploder exploder, Renderer[] renderers)
        {
            this.timer = timer;
            this.reloadTime = reloadTime;
            this.exploder = exploder;
            this.renderers = renderers;
        }

        public void Update()
        {
            for (int i = 0; i < renderers.Length; i++)
            {
                renderers[i].material.color = Color.Lerp(Color.white, Color.red, timer.Elapsed / reloadTime.Value);
            }

            if (timer.Elapsed >= reloadTime.Value)
                exploder.Explode();
        }
    }
}
