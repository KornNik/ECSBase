using UnityEngine;
using Audio;
using Helpers.Extensions;
using Data;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;

namespace Client
{
    sealed class AudioInitSystem : IEcsInitSystem
    {
        private readonly EcsWorldInject _world = default;

        private readonly EcsSharedInject<GlobalDataBundle> _sharedInject = default;
        private readonly EcsPoolInject<AudioComponents> _audioPool = default;

        public void Init(IEcsSystems systems)
        {
            var audioEntity = _world.Value.NewEntity();

            _audioPool.Value.Add(audioEntity);
            ref AudioComponents audioCompanents = ref _audioPool.Value.Get(audioEntity);

            var backgroundRecource = CustomResources.Load<AudioSource>
                (_sharedInject.Value.GetData<GameObjectsResourcesBundle>().
                GetAudioPath(AudioAssetType.BackgroundPrefab));
            audioCompanents.AudioSourcePoolablePrefab = CustomResources.Load<AudioSource>
                (_sharedInject.Value.GetData<GameObjectsResourcesBundle>().
                GetAudioPath(AudioAssetType.PooledPrefab));

            audioCompanents.AudioSourceBackground = GameObject.Instantiate(backgroundRecource);

            audioCompanents.AudioSourcePool = new AudioSourcePool(audioCompanents.AudioSourcePoolablePrefab);
            audioCompanents.AudioEventsHandler = new AudioEventsHandler();
            audioCompanents.AudioMixerMuter = _sharedInject.Value.GetData<AudioMixerVolumeMuter>();
        }
    }
}
