using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace MOATT.Levels.Waves.States
{
    public class Delay : State
    {
        private readonly Factory factory;

        public Delay(Factory factory)
        {
            this.factory = factory;
        }

        public class Factory : PlaceholderFactory<Delay> { }
    }
}

