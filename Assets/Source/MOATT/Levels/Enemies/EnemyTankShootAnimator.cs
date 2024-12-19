using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace MOATT.Levels.Enemies
{
    public class EnemyTankShootAnimator : MonoBehaviour, IAttackAnimator
    {
        [SerializeField] private ParticleSystem particles;

        public void Play(Vector3 target)
        {
            particles.Play(true);
        }
    }
}
