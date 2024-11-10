﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;
using MOATT.Levels.Map.Tiles;
using MOATT.Levels.Health;

namespace MOATT.Levels.Enemies
{
    public class EnemyFacade : MonoBehaviour
    {
        private HealthModel healthModel;

        [Inject]
        public void Construct(HealthModel healthModel)
        {
            this.healthModel = healthModel;
        }

        public void Damage(float damage)
        {
            healthModel.CurrentHealth -= damage;
        }

        public class Factory : PlaceholderFactory<EnemyFacade> { }
    }
}