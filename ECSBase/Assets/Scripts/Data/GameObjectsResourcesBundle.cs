using System;
using UI;
using UnityEngine;

namespace Data
{
    [Serializable]
    struct AudioAssetPath
    {
        public AudioAssetType Type;
        public string Path;
    }
    [Serializable]
    struct ScreenAssetPath
    {
        public ScreenTypes Type;
        public string Path;
    }
    enum AudioAssetType
    {
        None,
        BackgroundPrefab,
        PooledPrefab
    }
    [CreateAssetMenu(fileName ="ResourcesBundle",menuName ="Data/Resources")]
    class GameObjectsResourcesBundle : ScriptableObject
    {
        [SerializeField] private string MAIN_PREFABS_FOLER_NAME = "Prefabs/";
        [SerializeField] private string AUDIO_PREFABS_FOLDER_NAME = "Audio/";
        [SerializeField] private string GUI_PREFABS_FOLDER_NAME = "GUI/";

        [SerializeField] private AudioAssetPath[] _audioPath;
        [SerializeField] private ScreenAssetPath[] _screenPath;

        public string GetAudioPath(AudioAssetType audioType)
        {
            string audioName = default;
            for (int i = 0; i < _audioPath.Length; i++)
            {
                if (_audioPath[i].Type== audioType) audioName = _audioPath[i].Path;
            }
            var fullPath = Helpers.Extensions.StringBuilderExtender.CreateString
                (MAIN_PREFABS_FOLER_NAME, AUDIO_PREFABS_FOLDER_NAME, audioName);

            return fullPath;
        }
        public string GetScreenPath(ScreenTypes screenType)
        {
            string screenName = default;
            for (int i = 0; i < _audioPath.Length; i++)
            {
                if (_screenPath[i].Type == screenType) screenName = _screenPath[i].Path;
            }
            var fullPath = Helpers.Extensions.StringBuilderExtender.CreateString
                (MAIN_PREFABS_FOLER_NAME, GUI_PREFABS_FOLDER_NAME, screenName);

            return fullPath;
        }
    }
}