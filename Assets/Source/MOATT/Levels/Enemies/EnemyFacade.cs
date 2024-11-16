using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;
using DG.Tweening;

namespace MOATT.Levels.Enemies
{
    using Health;
    using BoundsCalculation;

    public class EnemyFacade : MonoBehaviour
    {
        private HealthModel healthModel;
        private EnemyRegistry registry;
        private BoundsCalculator boundsCalculator;

        public Vector3 Center => boundsCalculator.Bounds.center;

        private void Awake()
        {
            registry.Add(this);
        }

        [Inject]
        public void Construct(
            HealthModel healthModel,
            EnemyRegistry registry,
            BoundsCalculator boundsCalculator)
        {
            this.healthModel = healthModel;
            this.registry = registry;
            this.boundsCalculator = boundsCalculator;        
        }

        public void Damage(float damage)
        {
            healthModel.CurrentHealth -= damage;
        }

        public void Destroy()
        {
            Destroy(gameObject);
        }

        private void OnDestroy()
        {
            transform.DOKill();
            registry.Remove(this);
        }

        public class Factory : PlaceholderFactory<EnemyFacade> { }
    }
}
