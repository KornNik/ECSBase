using Audio;
using Data;
using UnityEngine;

namespace Client
{
    struct AudioComponents
    {
        public AudioSource AudioSourceBackground;
        public AudioSource AudioSourcePoolablePrefab;
        public AudioMixerVolumeMuter AudioMixerMuter;
        public AudioEventsHandler AudioEventsHandler;
        public AudioClip BackgroundAudioClip;
        public AudioSourcePool AudioSourcePool;
    }
}