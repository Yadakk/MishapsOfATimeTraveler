using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MOATT.UI
{
    public class SceneReloader : MonoBehaviour
    {
        [SerializeField] private SceneChanger changer;

        public void ReloadScene()
        {
            changer.ChangeScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
