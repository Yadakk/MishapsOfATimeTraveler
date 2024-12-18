using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Object = UnityEngine.Object;

namespace MOATT.Levels.Buildings.Bombs
{
    using Enemies;
    using MOATT.Levels.Units.Damage;
    using MOATT.Particles;
    using MOATT.Sound;
    using Units.Range;

    public class BombExploder
    {
        private readonly EnemyRegistry enemyRegistry;
        private readonly BuildingFacade facade;
        private readonly UnitRange unitRange;
        private readonly UnitDamage unitDamage;
        private readonly OneShotParticle explosionPrefab;
        private readonly Settings settings;

        public BombExploder(EnemyRegistry enemyRegistry, BuildingFacade facade, UnitDamage unitDamage, UnitRange unitRange, OneShotParticle explosionPrefab, Settings settings)
        {
            this.enemyRegistry = enemyRegistry;
            this.facade = facade;
            this.unitDamage = unitDamage;
            this.unitRange = unitRange;
            this.explosionPrefab = explosionPrefab;
            this.settings = settings;
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

            var soundGO = Object.Instantiate(settings.oneShotSoundPrefab, facade.transform.position, Quaternion.identity, facade.transform.parent);
            OneShotSound oneShotSound = soundGO.GetComponent<OneShotSound>();
            Object.Instantiate(explosionPrefab, facade.transform.position, Quaternion.identity, facade.transform.parent);
            oneShotSound.PlayOneShot(settings.clip);
            facade.Destroy();
        }

        [Serializable]
        public class Settings
        {
            public AudioClip clip;
            public GameObject oneShotSoundPrefab;
        }
    }
}
