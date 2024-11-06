using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace MOATT.Levels.Waves.States
{
    public class EnemiesAlive : State
    {
        private readonly Factory factory;

        public EnemiesAlive(Factory factory)
        {
            this.factory = factory;
        }

        public class Factory : PlaceholderFactory<EnemiesAlive> { }
    }
}
