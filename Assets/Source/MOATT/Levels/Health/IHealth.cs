using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MOATT.Levels.Health
{
    public interface IHealth
    {
        float MaxHealth { get; set; }
        float CurrentHealth { get; set; }

        event System.Action OnHealthChanged;
        event System.Action OnMaxHealthChanged;
    }
}
