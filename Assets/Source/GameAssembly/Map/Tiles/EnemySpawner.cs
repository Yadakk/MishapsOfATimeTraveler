using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace MishapsOfATimeTraveler.GameAssembly
{
    public class EnemySpawner : Tile
    {
        Enemy.Factory factory;

        [Inject]
        public void Construct(Enemy.Factory factory)
        {
            this.factory = factory;
        }

        public void Spawn()
        {
            Enemy enemy = factory.Create();
            enemy.transform.position = transform.position;
        }
    }
}