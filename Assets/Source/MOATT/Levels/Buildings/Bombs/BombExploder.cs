﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Object = UnityEngine.Object;

namespace MOATT.Levels.Buildings.Bombs
{
    using Enemies;
    using MOATT.Levels.Units.Damage;
    using MOATT.Particles;
    using Units.Range;

    public class BombExploder
    {
        private readonly EnemyRegistry enemyRegistry;
        private readonly BuildingFacade facade;
        private readonly UnitRange unitRange;
        private readonly UnitDamage unitDamage;
        private readonly OneShotParticle exlposionPrefab;

        public BombExploder(EnemyRegistry enemyRegistry, BuildingFacade facade, UnitDamage unitDamage, UnitRange unitRange, OneShotParticle exlposionPrefab)
        {
            this.enemyRegistry = enemyRegistry;
            this.facade = facade;
            this.unitDamage = unitDamage;
            this.unitRange = unitRange;
            this.exlposionPrefab = exlposionPrefab;
        }

        public void Explode()
        {
            foreach (var enemy in enemyRegistry.enemies)
            {
                if (Vector3.Distance(
                    enemy.transform.position,
                    facade.transform.position) > unitRange.Range) continue;

                enemy.Damage(unitDamage.Value);
            }

            Object.Instantiate(exlposionPrefab, facade.transform.position, Quaternion.identity, facade.transform.parent);
            facade.Destroy();
        }
    }
}
