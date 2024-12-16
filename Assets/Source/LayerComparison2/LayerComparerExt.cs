using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LayerComparison
{
    public static class LayerComparerExt
    {
        public static bool HasLayer(this LayerMask layerMask, int layer)
        {
            return layerMask == (layerMask | (1 << layer));
        }

        public static bool HasLayer(this LayerMask layerMask, GameObject gameObject)
        {
            return layerMask.HasLayer(gameObject.layer);
        }

        public static bool HasLayer(this LayerMask layerMask, Component component)
        {
            return layerMask.HasLayer(component.gameObject);
        }
    }
}
