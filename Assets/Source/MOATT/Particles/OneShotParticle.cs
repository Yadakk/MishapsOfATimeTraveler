using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MOATT.Particles
{
    public class OneShotParticle : MonoBehaviour
    {
        [SerializeField] private new ParticleSystem particleSystem;

        private void Start()
        {
            particleSystem.Play(true);
            Invoke(nameof(Destroy), particleSystem.main.duration);
        }

        private void Destroy()
        {
            Destroy(gameObject);
        }
    }
}
