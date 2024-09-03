using System.Collections.Generic;

namespace Helpers.Extensions
{
    enum DataType
    {
        None,
        DatasBundle
    }
    sealed class DataAssetsPath
    {
        public static readonly Dictionary<DataType, string> DatasPath = new Dictionary<DataType, string>
        {
            {
                DataType.DatasBundle, "Data/GlobalDataBundle"
            }
        };
    }
}
