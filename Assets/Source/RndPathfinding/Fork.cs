using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RndPathfinding
{
    public class Fork
    {
        public readonly ICell cell;
        public readonly int distanceFromPreviousFork;

        public Fork(ICell cell, int distanceFromPreviousFork)
        {
            this.cell = cell;
            this.distanceFromPreviousFork = distanceFromPreviousFork;
        }
    }
}
