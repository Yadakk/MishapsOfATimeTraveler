using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MOATT.Levels.Enemies
{
    public class EnemyWalkingAttackAnimator : MonoBehaviour, IAttackAnimator
    {
        private void OnDestroy()
        {
            transform.DOKill();
        }

        public void Play(Vector3 target)
        {
            transform.DOLocalRotate(Vector3.right * 10f, 0.1f).SetLoops(2, LoopType.Yoyo);
        }
    }
}
