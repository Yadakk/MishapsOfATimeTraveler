using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using LayerComparison;

namespace MOATT.Levels.Bullets
{
    using Layers;
    using Enemies;

    public class BulletFacade : MonoBehaviour
    {
        private LayerMasks layerMasks;

        private void OnTriggerEnter(Collider other)
        {
            var otherGameObject = other.gameObject;
            if (!layerMasks.enemyMask.HasLayer(otherGameObject.layer)) return;
            var enemy = otherGameObject.GetComponentInParent<EnemyFacade>();
            enemy.Damage(1f);
            Destroy();
        }

        [Inject]
        public void Construct(LayerMasks layerMasks, BulletTunables tunables)
        {
            this.layerMasks = layerMasks;

            var goParams = tunables.goParams;

            if (goParams.Position.HasValue) 
                transform.position = goParams.Position.Value;
        }

        public void Destroy()
        {
            Destroy(gameObject);
        }

        public class Factory : PlaceholderFactory<Object, BulletTunables, BulletFacade> { }
    }
}
