using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MOATT.Levels.Billboards
{
    public interface IDisplayer
    {
        public Bounds Bounds { get; }
        public float DisplayHeight { get; }
    }
}
