using MOATT.Levels.Enemies;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace MOATT.Abilities.Types
{
    public class RewindAbility : Ability
    {
        private readonly Settings settings;
        private readonly EnemyRegistry enemyRegistry;
        private readonly Description description;

        public override Sprite Sprite => settings.sprite;

        public RewindAbility(Settings settings, EnemyRegistry enemyRegistry, Description description)
        {
            this.settings = settings;
            this.enemyRegistry = enemyRegistry;
            this.description = description;
        }

        public override void Activate()
        {
            enemyRegistry.enemies.ForEach(enemy => enemy.EnemyPathHistory.LoadPositionInPast(settings.rewindDeltaSeconds));
        }

        public override string ToString() => description.ToString();

        [Serializable]
        public class Settings
        {
            public float rewindDeltaSeconds = 30f;
            public Sprite sprite;
        }

        public class Description
        {
            public override string ToString()
            {
                StringBuilder sb = new();
                sb.Append("The enemies get reverted to their positions where they were 30 seconds ago");
                return sb.ToString();
            }
        }
    }
}
