using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace MOATT.UI
{
    public class BackgroundDisplayer : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField] private Sprite backgroundOnHover;

        private BackgroundDisplayerGroup backgroundDisplayerGroup;

        [Inject]
        public void Construct(BackgroundDisplayerGroup backgroundDisplayerGroup)
        {
            this.backgroundDisplayerGroup = backgroundDisplayerGroup;
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            backgroundDisplayerGroup.SetBackground(backgroundOnHover);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            backgroundDisplayerGroup.SetBackground(null);
        }
    }
}
