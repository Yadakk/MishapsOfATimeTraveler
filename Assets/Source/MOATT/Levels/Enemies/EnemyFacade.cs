using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

namespace MOATT.Levels.Enemies
{
    using Health;

    public class EnemyFacade : MonoBehaviour
    {
        private HealthModel healthModel;
        private EnemyRegistry registry;

        [Inject]
        public void Construct(HealthModel healthModel, EnemyRegistry registry)
        {
            this.healthModel = healthModel;
            this.registry = registry;

            registry.Add(this);
        }

        public void Damage(float damage)
        {
            healthModel.CurrentHealth -= damage;
        }

        private void OnDestroy()
        {
            registry.Remove(this);
        }

        public class Factory : PlaceholderFactory<EnemyFacade> { }
    }
}
