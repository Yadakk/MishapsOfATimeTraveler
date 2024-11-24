using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MOATT.Levels.UnitRange
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
            gameObject.transform.localScale = Vector3.one * range * 2f;

            return true;
        }
    }
}
