using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace MOATT.Levels.Billboards
{
    public class BillboardFacade : MonoBehaviour, System.IDisposable
    {
        private BillboardPositioner positioner;

        public GameObject Gui { get; private set; }

        [Inject]
        public void Construct(BillboardPositioner positioner)
        {
            this.positioner = positioner;
        }

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

        public void SetSource(BillboardSource source)
        {
            positioner.Source = source;
        }

        public class Factory : PlaceholderFactory<BillboardSource, BillboardFacade> { }
    }
}
