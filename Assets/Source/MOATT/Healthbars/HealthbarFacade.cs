using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace MOATT.Levels.Healthbars
{
    using Health;

    public class HealthbarFacade : MonoBehaviour
    {
        public class Factory : PlaceholderFactory<HealthModel, HealthbarFacade> { }
    }
}
