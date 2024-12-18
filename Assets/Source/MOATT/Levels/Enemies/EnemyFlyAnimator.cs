using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MOATT.Levels.Enemies
{
    public class EnemyFlyAnimator : MonoBehaviour
    {
        private void Start()
        {
            transform.localPosition -= Vector3.up * 0.3f;
            transform.DOLocalMoveY(0.3f, Random.Range(1f, 1.1f)).
                SetEase(Ease.InOutSine).SetLoops(-1, LoopType.Yoyo);
        }

        private void OnDestroy()
        {
            transform.DOKill();
        }
    }
}
