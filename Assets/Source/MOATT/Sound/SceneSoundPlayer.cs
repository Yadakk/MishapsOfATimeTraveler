using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MOATT.Sound
{
    [RequireComponent(typeof(AudioSource))]
    public class SceneSoundPlayer : MonoBehaviour
    {
        private AudioSource audioSource;

        private void Awake()
        {
            audioSource = GetComponent<AudioSource>();
        }

        public void PlayOneShot(AudioClip clip, float volume = 1f)
        {
            audioSource.PlayOneShot(clip, volume);
        }
    }
}
