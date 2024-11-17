using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace MOATT.Levels.Enemies
{
    public class EnemyRotater : IInitializable, System.IDisposable
    {
        private Vector3 lastPos;

        private readonly EnemyFacade facade;

        public EnemyRotater(EnemyFacade facade)
        {
            this.facade = facade;
        }

        public void Initialize()
        {
            facade.OnStarted += StartHandler;
            facade.OnUpdated += UpdateHandler;
        }

        public void Dispose()
        {
            facade.OnStarted -= StartHandler;
            facade.OnUpdated -= UpdateHandler;
        }

        private void StartHandler()
        {
            UpdateLastPos();
        }

        private void UpdateHandler()
        {
            var transform = facade.transform;
            Vector3 delta = transform.position - lastPos;
            if (delta == Vector3.zero) return;
            transform.rotation = Quaternion.LookRotation(delta);
            UpdateLastPos();
        }

        private void UpdateLastPos()
        {
            lastPos = facade.transform.position;
        }
    }
}
