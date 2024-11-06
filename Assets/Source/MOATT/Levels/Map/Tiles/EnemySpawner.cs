using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using MOATT.Levels.Enemies;

namespace MOATT.Levels.Map.Tiles
{
    public class EnemySpawner : Tile
    {
        Enemy.Factory factory;

        [Inject]
        public void Construct(Enemy.Factory factory)
        {
            this.factory = factory;
        }

        public Enemy Spawn()
        {
            Enemy enemy = factory.Create();
            enemy.transform.position = transform.position;
            return enemy;
        }
    }
}