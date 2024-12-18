using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MOATT.Levels.Enemies
{
    public interface IAttackAnimator
    {
        void Play(Vector3 target);
    }
}
