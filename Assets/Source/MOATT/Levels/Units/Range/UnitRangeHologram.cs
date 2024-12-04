using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MOATT.Levels.Units.Range
{
    public class UnitRangeHologram : MonoBehaviour
    {
        public void DisplayRange(float range)
        {
            SetActive(TryDisplayRange(range));
        }

        public void SetActive(bool state)
        {
            gameObject.SetActive(state);
        }

        private bool TryDisplayRange(float range)
        {
            if (range <= 0f) return false;
            gameObject.transform.localScale = 2f * range * Vector3.one;

            return true;
        }
    }
}
