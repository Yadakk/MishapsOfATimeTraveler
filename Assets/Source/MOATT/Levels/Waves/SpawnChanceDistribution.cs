using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MOATT.Levels.Waves
{
    using Enemies;

    public class SpawnChanceDistribution
    {
        private readonly Settings settings;

        public SpawnChanceDistribution(Settings settings)
        {
            this.settings = settings;
        }

        public EnemyFacade GetRandomEnemy()
        {
            float roll = Random.Range(0f, 100f);
            float chanceSum = 0f;

            for (int i = 0; i < settings.enemyChances.Length; i++)
            {
                float newChanceSum = chanceSum + settings.enemyChances[i].spawnChancePercent;
                if (roll >= chanceSum && roll < newChanceSum) return settings.enemyChances[i].enemyPrefab;
                chanceSum = newChanceSum;
            }

            throw new System.Exception("Enemy not found");
        }

        [System.Serializable]
        public class Settings
        {
            public EnemyWithChance[] enemyChances;
        }

        [System.Serializable]
        public class EnemyWithChance
        {
            public EnemyFacade enemyPrefab;
            public float spawnChancePercent = 10f;
        }
    }
}
