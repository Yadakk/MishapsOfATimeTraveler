﻿using System.Collections;
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
        private EnemyPathfinder pathfinder;
        private Settings settings;

        public Vector3 Center => boundsCalculator.Bounds.center;
        public Vector3Int TilemapPos => enemyCellPositionCalculator.TilemapPosition;
        public EnemyPathfinder Pathfinder => pathfinder;
        public bool IsFlying => settings.isFlying;

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
            EnemyTilemapPositionCalculator enemyCellPositionCalculator,
            EnemyPathfinder pathfinder,
            Settings settings
            )
        {
            this.healthModel = healthModel;
            this.registry = registry;
            this.boundsCalculator = boundsCalculator;
            this.enemyCellPositionCalculator = enemyCellPositionCalculator;
            this.pathfinder = pathfinder;
            this.settings = settings;

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

        [System.Serializable]
        public class Settings
        {
            public bool isFlying = false;
        }

        public class Factory : PlaceholderFactory<Object, EnemyTunables, EnemyFacade> { }
    }
}
