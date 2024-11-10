using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using MOATT.Levels.Enemies;

namespace MOATT.Levels.Map.Tiles
{
    public class EnemySpawner : Tile
    {
        EnemyFacade.Factory factory;

        [Inject]
        public void Construct(EnemyFacade.Factory factory)
        {
            this.factory = factory;
        }

        public EnemyFacade Spawn()
        {
            EnemyFacade enemy = factory.Create();
            enemy.transform.position = transform.position;
            return enemy;
        }
    }
}