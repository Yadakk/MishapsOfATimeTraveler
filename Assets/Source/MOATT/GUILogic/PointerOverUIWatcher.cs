using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace MOATT.GUILogic
{
    public class PointerOverUIWatcher : ITickable
    {
        public bool IsPointerOverUI;

        public void Tick()
        {
            IsPointerOverUI = EventSystem.current.IsPointerOverGameObject();
        }
    }
}
