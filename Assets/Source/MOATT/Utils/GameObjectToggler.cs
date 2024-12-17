using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MOATT.Utils
{
    public class GameObjectToggler : MonoBehaviour
    {
        [SerializeField] private GameObject go;

        public void Toggle()
        {
            go.SetActive(!go.activeSelf);
        }
    }
}
