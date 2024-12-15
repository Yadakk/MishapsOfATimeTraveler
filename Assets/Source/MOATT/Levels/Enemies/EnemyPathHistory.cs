using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TimeTimers;
using UnityEngine;
using Zenject;

namespace MOATT.Levels.Enemies
{
    public class EnemyPathHistory : IInitializable, ITickable
    {
        private readonly EnemyPathfinder enemyPathfinder;
        private readonly Timer timer;
        private readonly Settings settings;

        private readonly List<float> positionHistory = new();

        public EnemyPathHistory(EnemyPathfinder enemyPathfinder, Timer timer, Settings settings)
        {
            this.enemyPathfinder = enemyPathfinder;
            this.timer = timer;
            this.settings = settings;
        }

        public void Initialize()
        {
            Reset();
        }

        public void Tick()
        {
            if (timer.Elapsed < settings.savePositionEverySeconds) return;
            positionHistory.Add(enemyPathfinder.PathTweener.position);
            positionHistory.RemoveAll(pos => pos < enemyPathfinder.PathTweener.position - settings.removeLastAtDeltaSeconds);
        }

        public void Reset()
        {
            positionHistory.Clear();
            positionHistory.Add(enemyPathfinder.PathTweener.position);
        }

        public void LoadPositionInPast(float deltaSeconds)
        {
            enemyPathfinder.PathTweener.fullPosition = positionHistory.Last(pos => pos > enemyPathfinder.PathTweener.fullPosition - deltaSeconds);
        }

        [Serializable]
        public class Settings
        {
            public float savePositionEverySeconds = 1f;
            public float removeLastAtDeltaSeconds = 30f;
        }
    }
}
