using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BoundsMeasurement
{
    public static class BoundsMeasurerExt
    {
        public static Bounds GetBounds(this Renderer[] renderers)
        {
            Bounds result = new();
            bool initFlag = false;

            foreach (var item in renderers)
            {
                if (!initFlag)
                {
                    result = item.bounds;
                    initFlag = true;
                    continue;
                }

                result.Encapsulate(item.bounds);
            }

            return result;
        }

        public static Bounds GetBounds(this GameObject gameObject)
        {
            return GetBounds(gameObject.GetComponentsInChildren<Renderer>());
        }

        public static Bounds GetBounds(this Component component)
        {
            return GetBounds(component.gameObject);
        }
    }  
}
