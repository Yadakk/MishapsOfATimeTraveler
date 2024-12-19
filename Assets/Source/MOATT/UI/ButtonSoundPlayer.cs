using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace MOATT.UI
{
    public class ButtonSoundPlayer : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField] private AudioClip pointerEnter;
        [SerializeField] private AudioClip pointerExit;
        [SerializeField] private AudioClip pointerClick;
        [SerializeField] private AudioSource audioSource;

        public void OnPointerEnter(PointerEventData eventData)
        {
            audioSource.PlayOneShot(pointerEnter);
        }
        public void OnPointerExit(PointerEventData eventData)
        {
            audioSource.PlayOneShot(pointerExit);
        }
        public void OnPointerClick()
        {
            audioSource.PlayOneShot(pointerClick);
        }
    }
}
