using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace MOATT.Levels.Bullets
{
    public class BulletTunables
    {
        public GameObjectCreationParameters goParams;
        public float damage;

        public BulletTunables(
            GameObjectCreationParameters goParams,
            float damage)
        {
            this.goParams = goParams;
            this.damage = damage;
        }
    }
}
