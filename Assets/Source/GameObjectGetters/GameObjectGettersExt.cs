using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameObjectGetters
{
    public static class GameObjectGettersExt
    {
        public static bool HasParent(this GameObject thisGO, GameObject thatGO)
        {
            var thisTransform = thisGO.transform;
            var thisParent = thisTransform.parent;

            if (thisParent == null) return false;
            if (thisParent.gameObject == thatGO) return true;

            return thisParent.gameObject.HasParent(thatGO);
        }
    }
}
