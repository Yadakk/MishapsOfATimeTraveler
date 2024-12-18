using MOATT.Particles;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using Object = UnityEngine.Object;

namespace MOATT.Levels.Enemies
{
    public class EnemyExplosionParticleEmitter
    {
        private readonly EnemyFacade facade;
        private readonly OneShotParticle explosionPrefab;

        public EnemyExplosionParticleEmitter(EnemyFacade facade, OneShotParticle explosionPrefab)
        {
            this.facade = facade;
            this.explosionPrefab = explosionPrefab;
        }

        public void EmitParticles()
        {
            Object.Instantiate(explosionPrefab, facade.transform.position, Quaternion.identity, facade.transform.parent);
        }
    }
}
