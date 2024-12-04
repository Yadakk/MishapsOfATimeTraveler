using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cannedenuum.UnityUtils.ValueChangeWatcher;

namespace MOATT.Levels.Economics
{
    [System.Serializable]
    public class PlayerResources
    {
        public ValueChangeWatcher<int> nutsAndBolts = new();
        public ValueChangeWatcher<int> scientists = new();
    }
}