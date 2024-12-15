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

        private Dictionary<float, float> positionHistory = new();

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
            positionHistory.Add(Time.time, enemyPathfinder.PathTweener.position);

            var deprecatedPositions = positionHistory.Where(pair => Time.time - pair.Key > settings.removeLastAtDeltaSeconds);
            for (int i = 0; i < deprecatedPositions.Count(); i++)
            {
                positionHistory.Remove(deprecatedPositions.ElementAt(i).Key);
            }

            positionHistory = new(positionHistory.OrderBy(x => x.Key));

            timer.Reset();
        }

        public void Reset()
        {
            positionHistory.Clear();
            positionHistory.Add(Time.time, enemyPathfinder.PathTweener.position);
        }

        public void LoadPositionInPast(float deltaSeconds)
        {
            float tragetPos = positionHistory.First(pair => pair.Key >= Time.time - deltaSeconds).Value;
            enemyPathfinder.SetPosition(tragetPos);
            Reset();
        }

        private void DebugHistory()
        {
            for (int i = 0; i < positionHistory.Count; i++)
            {
                Debug.Log($"Time: {positionHistory.ElementAt(i).Key}, Position: {positionHistory.ElementAt(i).Value}");
            }
        }

        [Serializable]
        public class Settings
        {
            public float savePositionEverySeconds = 1f;
            public float removeLastAtDeltaSeconds = 30f;
        }
    }
}
