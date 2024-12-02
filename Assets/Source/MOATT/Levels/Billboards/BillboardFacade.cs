using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace MOATT.Levels.Billboards
{
    public class BillboardFacade : MonoBehaviour, System.IDisposable
    {
        public GameObject Gui { get; private set; }

        public void Dispose()
        {
            if (this == null) return;
            Destroy(gameObject);
        }

        public void SetGUI(GameObject gameObject)
        {
            gameObject.transform.SetParent(transform, false);
            Gui = gameObject;
        }

        public class Factory : PlaceholderFactory<BillboardSource, BillboardFacade> { }
    }
}
