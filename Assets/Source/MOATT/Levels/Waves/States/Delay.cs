using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace MOATT.Levels.Waves.States
{
    public class Delay : State
    {
        public class Factory : PlaceholderFactory<Delay> { }
    }
}
