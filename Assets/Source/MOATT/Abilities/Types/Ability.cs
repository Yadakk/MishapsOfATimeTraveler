﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MOATT.Abilities.Types
{
    public abstract class Ability
    {
        public AbilityActiveDuration AbilityActiveDuration { get; protected set; }

        public abstract void Activate();
    }
}