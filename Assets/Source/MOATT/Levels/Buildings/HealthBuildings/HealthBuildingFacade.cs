using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace MOATT.Levels.Buildings.HealthBuildings
{
    using Health;

    public class HealthBuildingFacade : BuildingFacade
    {
        private HealthModel healthModel;

        [Inject]
        public void Construct(HealthModel healthModel)
        {
            this.healthModel = healthModel;
        }

        public void Damage(float damage)
        {
            healthModel.CurrentHealth -= damage;
        }
    }
}
