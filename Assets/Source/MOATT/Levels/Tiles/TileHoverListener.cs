using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace MOATT.Levels.Tiles
{
    public class TileHoverListener : MonoBehaviour
    {
        private TileFacade facade;

        public static TileFacade TileUnderMouse { get; private set; }
        public static event System.Action OnTileUnderMouseChanged;

        [Inject]
        public void Construct(TileFacade facade)
        {
            this.facade = facade;
        }

        private void OnMouseEnter()
        {
            TileUnderMouse = facade;
            OnTileUnderMouseChanged.Invoke();
        }

        private void OnMouseExit()
        {
            TileUnderMouse = null;
            OnTileUnderMouseChanged.Invoke();
        }
    }
}
