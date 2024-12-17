using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MOATT.Abilities.Types
{
    public abstract class Ability
    {
        public AbilityActiveDuration AbilityActiveDuration { get; protected set; }
        public abstract Sprite Sprite { get; }

        public abstract void Activate();
    }
}
