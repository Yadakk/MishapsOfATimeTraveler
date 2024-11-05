using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MOATT.Map.Waves.States
{
    public abstract class State : System.IDisposable
    {
        public virtual void Start()
        {
            // Optionally overridden
        }

        public virtual void Update()
        {
            // Optionally overridden
        }

        public virtual void Dispose()
        {
            // Optionally overridden
        }
    }
}
