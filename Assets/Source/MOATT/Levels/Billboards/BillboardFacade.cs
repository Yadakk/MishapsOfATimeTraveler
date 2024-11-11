using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace MOATT.Levels.Billboards
{
    public class BillboardFacade : MonoBehaviour, System.IDisposable
    {
        public void Dispose()
        {
            if (this == null) return;
            Destroy(gameObject);
        }

        public void SetGUI(GameObject gameObject)
        {
            Debug.Log(Time.frameCount);
            gameObject.transform.SetParent(transform, false);
        }

        public class Factory : PlaceholderFactory<BillboardSource, BillboardFacade> { }
    }
}
