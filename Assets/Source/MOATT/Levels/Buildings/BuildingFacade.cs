using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace MOATT.Levels.Buildings
{
    using Health;
    using Healthbars;

    public class BuildingFacade : MonoBehaviour
    {
        private HealthModel healthModel;
        private UnitHealthbarDisplayer healthbarDisplayer;

        [Inject]
        public void Construct(HealthModel healthModel, UnitHealthbarDisplayer healthbarDisplayer)
        {
            this.healthModel = healthModel;
            this.healthbarDisplayer = healthbarDisplayer;
        }

        public void Damage(float damage)
        {
            healthModel.CurrentHealth -= damage;
        }

        public void CreateHealthbar()
        {
            healthbarDisplayer.CreateHealthbar();
        }

        public void Destroy()
        {
            Destroy(gameObject);
        }

        public class Factory : PlaceholderFactory<Object, BuildingFacade> { }
    }
}
