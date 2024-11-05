using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace MOATT.Map.Waves.States
{
    public class EnemiesAlive : State
    {
        public class Factory : PlaceholderFactory<EnemiesAlive> { }
    }
}
