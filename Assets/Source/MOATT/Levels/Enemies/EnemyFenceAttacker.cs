using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cannedenuum.ZenjectUtils.MonoInterfaces;

namespace MOATT.Levels.Enemies
{
    using Buildings.Fence;
    using Units.Damage;

    public class EnemyFenceAttacker : IUpdatable
    {
        private readonly EnemyPathfinder pathfinder;
        private readonly EnemyReloader reloader;
        private readonly UnitDamage unitDamage;

        public EnemyFenceAttacker(EnemyPathfinder pathfinder, EnemyReloader reloader, UnitDamage unitDamage)
        {
            this.pathfinder = pathfinder;
            this.reloader = reloader;
            this.unitDamage = unitDamage;
        }

        public void Update()
        {
            foreach(var blocker in pathfinder.blockers)
            {
                if (blocker is not FenceUnitBlocker) continue;
                if (!reloader.ReadyToAttack) continue;
                var fenceBlocker = blocker as FenceUnitBlocker;
                fenceBlocker.BuildingFacade.Damage(unitDamage.Value);
                reloader.ReadyToAttack = false;
                break;
            }
        }
    }
}
