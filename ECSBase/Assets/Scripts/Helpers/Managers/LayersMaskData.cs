using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "LayersData", menuName = "Data/LayersData")]
    sealed class LayersMaskData : ScriptableObject
    {
        [SerializeField] private string _ui = "UI";
        [SerializeField] private string _default = "Default";
        [SerializeField] private string _ground = "Ground";
        [SerializeField] private int _defaultLayer = 0;

        public int DefaultLayer => LayerMask.GetMask(_default);
        public int UiLayer => LayerMask.GetMask(_ui);
        public int Ground => LayerMask.GetMask(_ground);
    }
}
