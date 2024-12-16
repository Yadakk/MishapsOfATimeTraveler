using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace MOATT.Utils
{
    public class ScalableTimer : ITickable
    {
        public float timeScale = 1f;

        public float Elapsed { get; private set; }

        public void Reset()
        {
            Elapsed = 0f;
        }

        public void Tick()
        {
            Elapsed += Time.deltaTime * timeScale;
        }
    }
}
