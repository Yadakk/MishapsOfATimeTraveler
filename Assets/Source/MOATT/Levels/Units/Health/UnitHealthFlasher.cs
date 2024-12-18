using MOATT.Levels.Health;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace MOATT.Levels.Units.Health
{
    public class UnitHealthFlasher : IInitializable, IDisposable
    {
        private readonly Renderer[] renderers;
        private readonly HealthModel healthModel;

        public UnitHealthFlasher(Renderer[] renderers, HealthModel healthModel)
        {
            this.renderers = renderers;
            this.healthModel = healthModel;
        }

        public void Initialize()
        {
            healthModel.OnHealthChangedOldNew += HealthChangedHandler;
        }

        public void Dispose()
        {
            healthModel.OnHealthChangedOldNew -= HealthChangedHandler;
        }

        private void HealthChangedHandler(float oldHealth, float newHealth)
        {
            for (int i = 0; i < renderers.Length; i++)
            {
                Debug.Log(renderers[i].materials);
                renderers[i].material.color = Color.red;
            }
        }
    }
}
