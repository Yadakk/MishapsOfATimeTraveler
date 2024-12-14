using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MOATT.Levels.GameplayConditions
{
    public class LevelLostInvoker
    {
        public event Action OnLost;

        public bool HasLost { get; private set; }

        public void InvokeLose()
        {
            if (HasLost) return;
            HasLost = true;
            OnLost?.Invoke();
        }
    }
}
