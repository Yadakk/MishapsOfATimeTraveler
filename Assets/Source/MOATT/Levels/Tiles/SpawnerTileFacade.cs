using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using MOATT.Levels.Enemies;

namespace MOATT.Levels.Tiles
{
    public class SpawnerTileFacade : TileFacade
    {
        EnemyFacade.Factory factory;

        [Inject]
        public void Construct(EnemyFacade.Factory factory)
        {
            this.factory = factory;
        }

        public EnemyFacade Spawn(EnemyFacade enemyPrefab)
        {
            EnemyFacade enemy = factory.Create(enemyPrefab, new(transform.position));
            return enemy;
        }
    }
}