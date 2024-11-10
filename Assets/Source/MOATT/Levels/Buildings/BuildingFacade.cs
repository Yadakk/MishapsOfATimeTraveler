using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace MOATT.Levels.Buildings
{
    using Health;

    public class BuildingFacade : MonoBehaviour
    {
        private HealthModel healthModel;

        [Inject]
        public void Construct(HealthModel healthModel)
        {
            this.healthModel = healthModel;
        }

        public void Damage(int damage)
        {
            healthModel.CurrentHealth -= damage;
        }
    }
}
