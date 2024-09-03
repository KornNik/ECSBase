using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "AxisNamesData", menuName = "Data/AxisNamesData")]
    sealed class AxisNamesData : ScriptableObject
    {
        [SerializeField] private string _fire1 = "Fire1";
        [SerializeField] private string _fire2 = "Fire2";
        [SerializeField] private string _cancle = "Cancel";
        [SerializeField] private string _horizontal = "Horizontal";
        [SerializeField] private string _vertical = "Vertical";

        public string Fire1 => _fire1;
        public string Fire2  => _fire2; 
        public string Cancle  => _cancle; 
        public string Horizontal => _horizontal;
        public string Vertical => _vertical;
    }
}
