using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MOATT.Levels.Enemies
{
    public class EnemyRegistry
    {
        public readonly List<EnemyFacade> enemies = new();

        public void Add(EnemyFacade enemy)
        {
            enemies.Add(enemy);
        }

        public void Remove(EnemyFacade enemy)
        {
            enemies.Remove(enemy);
        }
    }
}
