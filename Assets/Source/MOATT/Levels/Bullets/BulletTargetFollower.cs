using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace MOATT.Levels.Bullets
{
    using Enemies;
    using Buildings.Turrets;

    public class BulletTargetFollower : ITickable
    {
        private readonly EnemyFacade target;
        private readonly BulletFacade facade;

        public BulletTargetFollower(TurretTargetPicker targetPicker, BulletFacade facade = null)
        {
            target = targetPicker.Enemy;
            this.facade = facade;
        }

        private Transform Transform => facade.transform;

        public void Tick()
        {
            if (target != null)
            {
                MoveToTarget();
            }
            else
            {
                MoveForward();
            }
        }

        private void MoveToTarget()
        {
            var targetCenter = target.Center;
            Transform.SetPositionAndRotation(
                Vector3.MoveTowards(Transform.position, targetCenter, 1f),
                Quaternion.LookRotation(targetCenter - Transform.position));
        }

        private void MoveForward()
        {
            Transform.position += Transform.forward;
        }
    }
}
