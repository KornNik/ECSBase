using Client;
using Data;
using Helpers.Extensions;
using UnityEngine;

namespace Controller
{
    sealed class Startup : MonoBehaviour
    {
        private EcsStartup _ecsStartup;
        private GlobalDataBundle _globalDataBundle;

        private void Awake()
        {
            _globalDataBundle = CustomResources.Load<GlobalDataBundle>(DataAssetsPath.DatasPath[DataType.DatasBundle]);

            _ecsStartup = new EcsStartup(_globalDataBundle);
            _ecsStartup.InitializeSystems();
        }
        private void Start()
        {
            
        }
        private void OnEnable()
        {
            
        }
        private void OnDisable()
        {
            
        }
        private void OnDestroy()
        {
            _ecsStartup.OnDestroySystems();
        }
        private void Update()
        {
            _ecsStartup.UpdateSystems();
        }
        private void FixedUpdate()
        {
            _ecsStartup.FixedUpdateSystems();
        }
        private void LateUpdate()
        {
            
        }
    }
}
