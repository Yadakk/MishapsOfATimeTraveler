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
        private EnemyTilemapPositionCalculator enemyCellPositionCalculator;

        public Vector3 Center => boundsCalculator.Bounds.center;
        public Vector3Int TilemapPos => enemyCellPositionCalculator.TilemapPosition;

        private void Awake()
        {
            registry.Add(this);
        }

        [Inject]
        public void Construct(
            EnemyTunables tunables,
            HealthModel healthModel,
            EnemyRegistry registry,
            BoundsCalculator boundsCalculator,
            EnemyTilemapPositionCalculator enemyCellPositionCalculator
            )
        {
            this.healthModel = healthModel;
            this.registry = registry;
            this.boundsCalculator = boundsCalculator;
            this.enemyCellPositionCalculator = enemyCellPositionCalculator;

            transform.position = tunables.initPos;
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

        public class Factory : PlaceholderFactory<Object, EnemyTunables, EnemyFacade> { }
    }
}
