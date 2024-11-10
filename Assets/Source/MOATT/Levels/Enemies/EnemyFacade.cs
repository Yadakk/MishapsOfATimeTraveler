using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;
using MOATT.Levels.Map.Tiles;

namespace MOATT.Levels.Enemies
{
    public class EnemyFacade : MonoBehaviour
    {


        public class Factory : PlaceholderFactory<EnemyFacade> { }
    }
}
