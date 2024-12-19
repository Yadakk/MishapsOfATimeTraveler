using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cannedenuum.ZenjectUtils.MonoInterfaces;

namespace MOATT.Levels.Enemies.Destroyers
{
    using Buildings;
    using Units.Range;
    using Units.Damage;

    public class DestroyerEnemyAttacker : IUpdatable
    {
        private readonly Settings settings;
        private readonly BuildingRegistry buildingRegistry;
        private readonly UnitRange unitRange;
        private readonly EnemyFacade facade;
        private readonly EnemyPathfinder pathfinder;
        private readonly EnemyReloader enemyReloader;
        private readonly UnitDamage unitDamage;
        private readonly IAttackAnimator attackAnimator;
        private AudioSource audioSource;
        private AudioClip attackSound;

        public DestroyerEnemyAttacker(Settings settings, BuildingRegistry buildingRegistry = null, UnitRange unitRange = null, EnemyFacade facade = null, EnemyPathfinder pathfinder = null, EnemyReloader enemyReloader = null, UnitDamage unitDamage = null, IAttackAnimator attackAnimator = null)
        {
            this.settings = settings;
            this.buildingRegistry = buildingRegistry;
            this.unitRange = unitRange;
            this.facade = facade;
            this.pathfinder = pathfinder;
            this.enemyReloader = enemyReloader;
            this.unitDamage = unitDamage;
            this.attackAnimator = attackAnimator;
            audioSource = facade.AudioSource;
            attackSound = settings.attackSound;
        }

        public void Update()
        {
            bool wasBuildingFound = TryFindBuilding(out var building);

            if (wasBuildingFound)
            {
                if (settings.stopsToAttack) pathfinder.RegisterBlocker(this);
                if (enemyReloader.ReadyToAttack)
                {
                    building.Damage(unitDamage.Value);
                    attackAnimator?.Play(building.transform.position);
                    audioSource.PlayOneShot(attackSound);
                    enemyReloader.ReadyToAttack = false;
                }
            }
            else pathfinder.UnregisterBlocker(this);
        }

        private bool TryFindBuilding(out BuildingFacade foundBuilding)
        {
            foundBuilding = null;

            foreach (var building in buildingRegistry.buildings)
            {
                if (Vector3.Distance(
                    facade.transform.position,
                    building.transform.position) > unitRange.Range) continue;
                if (building.Type != settings.canDamageTypes) continue;
                if (building.HealthModel == null) continue;
                foundBuilding = building;
                return true;
            }
            return false;
        }

        [System.Serializable]
        public class Settings
        {
            public BuildingFacade.BuildingType canDamageTypes;
            public bool stopsToAttack = true;
            public AudioClip attackSound;
        }
    }
}
