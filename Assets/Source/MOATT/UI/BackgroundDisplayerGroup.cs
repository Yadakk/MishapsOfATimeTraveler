using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MOATT.UI
{
    public class BackgroundDisplayerGroup : MonoBehaviour
    {
        [SerializeField] private Image image;

        private Sprite defaultBg;

        private void Awake()
        {
            defaultBg = image.sprite;
        }

        public void SetBackground(Sprite background)
        {
            image.sprite = background != null ? background : defaultBg;
        }
    }
}
