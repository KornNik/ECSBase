using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "SettingsData", menuName = "Data/Settings")]
    public class SettingsData : ScriptableObject
    {
        [SerializeField] private int _defaultVsyncCount = 1;
        [SerializeField] private int _defaultFreameRate = 60;
        [SerializeField] private bool _defaultCursorState = false;
        [SerializeField] private CursorLockMode _defaultCursorLockMode = CursorLockMode.Locked;

        public int DefaultVsyncCount => _defaultVsyncCount;
        public int DefaultFrameRate => _defaultFreameRate;
        public bool DefaultCursorState => _defaultCursorState; 
        public CursorLockMode DefaultCursorLockMode => _defaultCursorLockMode;
    }
}