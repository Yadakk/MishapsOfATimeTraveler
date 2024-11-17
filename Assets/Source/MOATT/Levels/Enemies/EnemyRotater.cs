using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace MOATT.Levels.Enemies
{
    using Tiles;

    public class EnemyRotater : IInitializable, ITickable, System.IDisposable
    {
        private Vector3 lastPos;

        private readonly EnemyFacade facade;
        private readonly EnemyPathfinder pathfinder;

        public EnemyRotater(EnemyFacade facade, EnemyPathfinder pathfinder = null)
        {
            this.facade = facade;
            this.pathfinder = pathfinder;
        }

        private Transform Transform => facade.transform;

        public void Initialize()
        {
            pathfinder.OnPathCreated += PathCreatedHandler;
        }

        public void Dispose()
        {
            pathfinder.OnPathCreated -= PathCreatedHandler;
        }

        private void PathCreatedHandler(TileFacade[] path)
        {
            Vector3 delta = path[1].transform.position - path[0].transform.position;
            LookDelta(delta);
            UpdateLastPos();
        }

        public void Tick()
        {
            Vector3 delta = Transform.position - lastPos;
            LookDelta(delta);
            UpdateLastPos();
        }

        private void LookDelta(Vector3 delta)
        {
            if (delta == Vector3.zero) return;
            Transform.rotation = Quaternion.LookRotation(delta);
        }

        private void UpdateLastPos()
        {
            lastPos = facade.transform.position;
        }
    }
}
