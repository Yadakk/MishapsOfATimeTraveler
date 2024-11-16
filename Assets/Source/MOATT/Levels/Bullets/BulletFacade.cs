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
        public void Construct(LayerMasks layerMasks)
        {
            this.layerMasks = layerMasks;
        }

        public void Destroy()
        {
            Destroy(gameObject);
        }

        public class Factory : PlaceholderFactory<BulletFacade> { }
    }
}
