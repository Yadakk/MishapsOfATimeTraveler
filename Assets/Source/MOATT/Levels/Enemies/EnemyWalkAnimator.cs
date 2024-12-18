using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Zenject;
using MOATT.Levels.Tiles;

namespace MOATT.Levels.Enemies
{
    public class EnemyWalkAnimator : MonoBehaviour
    {
        private EnemyPathfinder enemyPathfinder;
        private Tweener tweener;

        [Inject]
        public void Construct(EnemyPathfinder enemyPathfinder)
        {
            this.enemyPathfinder = enemyPathfinder;
        }

        private void Awake()
        {
            enemyPathfinder.OnTimescaleChanged += TimescaleChangedHandler;
            enemyPathfinder.OnTileReached += Stop;
            enemyPathfinder.OnPositionChanged += Play;
        }

        private void OnDestroy()
        {
            transform.DOKill();
            enemyPathfinder.OnTimescaleChanged -= TimescaleChangedHandler;
            enemyPathfinder.OnTileReached -= Stop;
            enemyPathfinder.OnPositionChanged -= Play;
        }

        private void Start()
        {
            transform.localRotation = Quaternion.Euler(Vector3.forward * -5f);
            tweener = transform.DOLocalRotate(
                Vector3.forward * 5f, 0.5f / enemyPathfinder.TilesPerSecond * Random.Range(0.9f, 1.1f)).
                SetEase(Ease.InOutSine).SetLoops(-1, LoopType.Yoyo);
        }

        private void TimescaleChangedHandler(float timeScale)
        {
            tweener.timeScale = timeScale;
        }

        private void Stop(TileFacade tile)
        {
            tweener.Pause();
        }

        private void Play()
        {
            tweener.Play();
        }
    }
}
