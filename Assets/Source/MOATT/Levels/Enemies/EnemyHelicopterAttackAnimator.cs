using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using TimeTimers;
using static UnityEngine.GraphicsBuffer;

namespace MOATT.Levels.Enemies
{
    public class EnemyHelicopterAttackAnimator : MonoBehaviour, IAttackAnimator
    {
        [SerializeField] private LineRenderer lineRenderer;

        private Timer timer;
        private bool timerFlag;

        [Inject]
        public void Construct(Timer timer)
        {
            this.timer = timer;
        }

        private void Update()
        {
            if (!timerFlag) return;
            lineRenderer.enabled = timer.Elapsed <= 0.1f;
            lineRenderer.SetPosition(0, transform.position);
        }

        public void Play(Vector3 target)
        {
            timer.Reset();
            timerFlag = true;

            lineRenderer.SetPosition(1, target);
        }
    }
}
