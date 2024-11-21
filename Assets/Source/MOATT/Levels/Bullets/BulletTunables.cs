using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace MOATT.Levels.Bullets
{
    public class BulletTunables
    {
        public GameObjectCreationParameters goParams;

        public BulletTunables(GameObjectCreationParameters goParams)
        {
            this.goParams = goParams;
        }
    }
}
