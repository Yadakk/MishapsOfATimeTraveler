using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace MOATT.InputLogic
{
    public class InteractionModeSwitcher : IInitializable, System.IDisposable
    {
        public readonly InputAsset inputAsset;

        private InputActionMap currentMap;

        public event System.Action<InputActionMap> OnModeChanged;

        public InputActionMap CurrentMap 
        { 
            get => currentMap;
            set
            {
                currentMap?.Disable();
                currentMap = value;
                currentMap?.Enable();
                OnModeChanged?.Invoke(currentMap);
            }
        }

        public InteractionModeSwitcher(InputAsset inputAsset)
        {
            this.inputAsset = inputAsset;
        }

        public void Initialize()
        {
            CurrentMap = inputAsset.Selection;
        }

        public void Dispose()
        {
            CurrentMap = null;
        }
    }
}
