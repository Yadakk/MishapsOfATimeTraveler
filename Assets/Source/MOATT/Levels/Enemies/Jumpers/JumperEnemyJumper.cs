using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using DG.Tweening;

namespace MOATT.Levels.Enemies.Jumpers
{
    public class JumperEnemyJumper : MonoBehaviour
    {
        private EnemyPathfinder pathfinder;

        private void Awake()
        {
            pathfinder.OnFenceIgnoreCountChanged += Jump;
        }

        private void OnDestroy()
        {
            pathfinder.OnFenceIgnoreCountChanged -= Jump;
            transform.DOKill();
        }

        [Inject]
        public void Construct(EnemyPathfinder pathfinder)
        {
            this.pathfinder = pathfinder;
        }

        private void Jump()
        {
            transform.DOLocalJump(transform.localPosition, 1f, 1, 1f);
        }
    }
}
