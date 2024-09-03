using System.Collections.Generic;
using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "GlobalDataBundle", menuName = "Data/GlobalDataBundle")]
    public class GlobalDataBundle : ScriptableObject
    {
        [SerializeField] private List<ScriptableObject> _datas;

        public T GetData<T>() where T : ScriptableObject
        {
            foreach (var item in _datas)
            {
                if (item is T)
                {
                    return item as T;
                }
            }
            return null;
        }
    }
}