using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MOATT.Levels.UI
{
    public class GamePauser : MonoBehaviour
    {
        [SerializeField] private GameObject menu;

        private void Start()
        {
            menu.SetActive(false);
        }

        public void Toggle()
        {
            bool isPaused = Time.timeScale == 0f;
            Time.timeScale = isPaused ? 1f : 0f;
            menu.SetActive(!isPaused);
        }

        private void OnDestroy()
        {
            Time.timeScale = 1f;
        }
    }
}
