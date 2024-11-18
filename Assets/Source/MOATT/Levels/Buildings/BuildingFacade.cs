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
        public void Construct(HealthModel healthModel, [InjectOptional] BuildingTunables tunables)
        {
            this.healthModel = healthModel;

            if (tunables == null) return;
            tunables.initTile.SetBuilding(this);
        }

        public void Damage(float damage)
        {
            healthModel.CurrentHealth -= damage;
        }

        public void Destroy()
        {
            Destroy(gameObject);
        }

        public class Factory : PlaceholderFactory<Object, BuildingTunables, BuildingFacade> { }
    }
}
