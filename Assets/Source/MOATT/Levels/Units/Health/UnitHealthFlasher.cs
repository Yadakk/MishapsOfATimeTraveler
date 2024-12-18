using MOATT.Levels.Health;
using System;
using System.Collections;
using System.Collections.Generic;
using TimeTimers;
using UnityEngine;
using Zenject;

namespace MOATT.Levels.Units.Health
{
    public class UnitHealthFlasher : IInitializable, ITickable, IDisposable
    {
        private readonly Renderer[] renderers;
        private readonly HealthModel healthModel;
        private readonly Timer timer;

        private bool nonOriginalColorFlag;

        public UnitHealthFlasher(Renderer[] renderers, HealthModel healthModel, Timer timer)
        {
            this.renderers = renderers;
            this.healthModel = healthModel;
            this.timer = timer;
        }

        public void Initialize()
        {
            healthModel.OnHealthChangedOldNew += HealthChangedHandler;
        }

        public void Tick()
        {
            if (!nonOriginalColorFlag) return;
            if (timer.Elapsed < 0.1f) return;
            ResetColor();
        }

        public void Dispose()
        {
            healthModel.OnHealthChangedOldNew -= HealthChangedHandler;
        }

        private void HealthChangedHandler(float oldHealth, float newHealth)
        {
            MaterialPropertyBlock props = new();
            props.SetColor("_BaseColor", newHealth < oldHealth ? Color.red : Color.green);

            for (int i = 0; i < renderers.Length; i++)
            {
                for (int j = 0; j < renderers[i].materials.Length; j++)
                {
                    renderers[i].SetPropertyBlock(props, j);
                }
            }

            timer.Reset();
            nonOriginalColorFlag = true;
        }

        private void ResetColor()
        {
            MaterialPropertyBlock props = new();

            for (int i = 0; i < renderers.Length; i++)
            {
                for (int j = 0; j < renderers[i].materials.Length; j++)
                {
                    renderers[i].SetPropertyBlock(props, j);
                }
            }

            nonOriginalColorFlag = false;
        }
    }
}
