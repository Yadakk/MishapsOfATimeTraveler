using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace MOATT.UI
{
    public class SceneChanger : MonoBehaviour
    {
        [SerializeField] private GameObject loadingScreenPrefab;
        [SerializeField] private Transform canvasTransform;
        [SerializeField] private string sceneName;

        private Slider loadingSlider;
        private AsyncOperation loadingOperation;

        private void Update()
        {
            if (loadingSlider == null) return;
            if (loadingOperation == null) return;
            loadingSlider.value = loadingOperation.progress;
        }

        public void ChangeScene()
        {
            GameObject loadingScreen = Instantiate(loadingScreenPrefab, canvasTransform);
            loadingScreen.transform.SetAsLastSibling();
            loadingSlider = loadingScreen.GetComponentInChildren<Slider>();
            loadingOperation = SceneManager.LoadSceneAsync(sceneName);
        }

        public void ChangeScene(int buildIndex)
        {
            GameObject loadingScreen = Instantiate(loadingScreenPrefab, canvasTransform);
            loadingScreen.transform.SetAsLastSibling();
            loadingSlider = loadingScreen.GetComponentInChildren<Slider>();
            loadingOperation = SceneManager.LoadSceneAsync(buildIndex);
        }
    }
}
