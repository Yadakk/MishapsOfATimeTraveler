using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace MOATT.Levels.Buildings
{
    using Health;

    public class BuildingFacade : MonoBehaviour
    {
        [Inject]
        public void Construct([InjectOptional] BuildingTunables tunables)
        {
            if (tunables == null) return;
            tunables.initTile.SetBuilding(this);
        }

        public void Destroy()
        {
            Destroy(gameObject);
        }

        public class Factory : PlaceholderFactory<Object, BuildingTunables, BuildingFacade> { }
    }
}
