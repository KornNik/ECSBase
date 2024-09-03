using Data;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;

namespace Client
{
    sealed class StartSettingsSystem : IEcsInitSystem
    {
        private readonly EcsSharedInject<GlobalDataBundle> _sharedInject = default;

        public void Init(IEcsSystems systems)
        {
            var settingsData = _sharedInject.Value.GetData<SettingsData>();

            SetFPSState(settingsData);
            SetCursorState(settingsData);
        }
        private void SetFPSState(SettingsData settingsData)
        {
            QualitySettings.vSyncCount = settingsData.DefaultVsyncCount;
            Application.targetFrameRate = settingsData.DefaultFrameRate;
        }
        private void SetCursorState(SettingsData settingsData)
        {
            Cursor.lockState = settingsData.DefaultCursorLockMode;
            Cursor.visible = settingsData.DefaultCursorState;
        }
    }
}