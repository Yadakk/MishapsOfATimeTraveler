using MOATT.Sound;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace MOATT.Abilities
{
    public class LevelAbilitySoundPlayer
    {
        private readonly SceneSoundPlayer sceneSoundPlayer;
        private readonly Settings settings;

        public LevelAbilitySoundPlayer(SceneSoundPlayer sceneSoundPlayer, Settings settings)
        {
            this.sceneSoundPlayer = sceneSoundPlayer;
            this.settings = settings;
        }

        public void PlayCharged()
        {
            sceneSoundPlayer.PlayOneShot(settings.chargedSound, settings.chargedSoundVolume);
        }

        public void PlayActivated()
        {
            sceneSoundPlayer.PlayOneShot(settings.activatedSound, settings.activatedSoundVolume);
        }

        [Serializable]
        public class Settings
        {
            public AudioClip chargedSound;
            [Range(0f, 1f)] public float chargedSoundVolume = 0.5f;
            public AudioClip activatedSound;
            [Range(0f, 1f)] public float activatedSoundVolume = 1f;
        }
    }
}
