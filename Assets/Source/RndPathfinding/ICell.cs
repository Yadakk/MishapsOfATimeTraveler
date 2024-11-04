using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RndPathfinding
{
    public interface ICell
    {
        public Vector2Int CellPos { get; }
        public bool IsWalkable { get; }
    }
}
