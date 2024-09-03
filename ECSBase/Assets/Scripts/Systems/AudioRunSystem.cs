using Data;
using Audio;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;

namespace Client
{
    sealed class AudioRunSystem : IEcsRunSystem
    {
        private readonly EcsSharedInject<GlobalDataBundle> _sharedInject = default;
        private readonly EcsFilterInject<Inc<AudioComponents>> _filter = default;
        private readonly EcsPoolInject<AudioComponents> _audioPool = default;


        public void Run(IEcsSystems systems)
        {
            foreach (int entity in _filter.Value)
            {
                ref AudioComponents audioComponents = ref _audioPool.Value.Get(entity);

                if (!audioComponents.AudioSourceBackground.isPlaying &&
                    !ReferenceEquals(audioComponents.BackgroundAudioClip, null))
                {
                    audioComponents.BackgroundAudioClip = null;
                }
            }
        }

        public void PlaySound(SoundEventInfo soudnInfo)
        {
            foreach (int entity in _filter.Value)
            {
                ref AudioComponents audioComponents = ref _audioPool.Value.Get(entity);

                if (soudnInfo.IsOneShot)
                {
                    audioComponents.AudioSourcePool.PlayAtPointOneShot(soudnInfo.AudioClip, soudnInfo.PlayPosition, soudnInfo.SoundVolume);
                }
                else
                {
                    audioComponents.AudioSourcePool.PlayAtPoint(soudnInfo.AudioClip, soudnInfo.PlayPosition, soudnInfo.SoundVolume);
                }
            }
        }

        public void SwitchMutedState()
        {
            foreach (int entity in _filter.Value)
            {
                ref AudioComponents audioComponents = ref _audioPool.Value.Get(entity);

                audioComponents.AudioMixerMuter.Muted = !audioComponents.AudioMixerMuter.Muted;
            }
        }
        public void SetSoundStatus(bool status)
        {
            foreach (int entity in _filter.Value)
            {
                ref AudioComponents audioComponents = ref _audioPool.Value.Get(entity);

                audioComponents.AudioMixerMuter.Muted = status;
            }
        }
    }
}
