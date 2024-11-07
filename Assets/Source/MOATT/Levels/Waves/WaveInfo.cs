using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MOATT.Levels.Waves
{
    using Enemies;

    public class WaveInfo
    {
        public readonly List<Enemy> enemies = new();

        public int CountClearNullEnemies()
        {
            enemies.RemoveAll(enemy => enemy == null);
            return enemies.Count;
        }
    }
}
