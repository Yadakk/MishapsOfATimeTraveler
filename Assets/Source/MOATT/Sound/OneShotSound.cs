using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MOATT.Sound
{
    public class OneShotSound : MonoBehaviour
    {
        [SerializeField] private AudioSource source;

        private bool flag;

        public void PlayOneShot(AudioClip clip)
        {
            if (flag) return;
            source.PlayOneShot(clip);
            Invoke(nameof(Destroy), clip.length);
            flag = true;
        }

        private void Destroy()
        {
            Destroy(gameObject);
        }
    }
}
