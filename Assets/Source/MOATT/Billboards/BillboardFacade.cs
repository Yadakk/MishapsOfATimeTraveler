using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace MOATT.Billboards
{
    public class BillboardFacade : MonoBehaviour, System.IDisposable
    {
        public void Dispose()
        {
            if (this == null) return;
            Destroy(gameObject);
        }

        public class Factory : PlaceholderFactory<BillboardSource, BillboardFacade> { }
    }
}
