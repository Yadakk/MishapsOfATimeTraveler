using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MOATT.Levels.Buildings
{
    public interface IMultiplyableBuildingReloader
    {
        void AddMultiplier(object obj, float value);
        public void RemoveMultiplier(object obj);
    }
}
