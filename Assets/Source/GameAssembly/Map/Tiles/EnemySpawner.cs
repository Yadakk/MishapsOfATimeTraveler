using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace MishapsOfATimeTraveler.GameAssembly
{
    public class EnemySpawner : Tile
    {
        Enemy.Factory factory;

        private void Start()
        {
            InvokeRepeating(nameof(Spawn), 1f, 1f);
        }

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