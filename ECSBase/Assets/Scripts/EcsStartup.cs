using Data;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;

namespace Client
{
    sealed class EcsStartup
    {
        private EcsWorld _world = null;
        private IEcsSystems _updateSystems;
        private IEcsSystems _initializeSystems;
        private IEcsSystems _fixedUpdateSystems;
        private GlobalDataBundle _dataBundle;

        public EcsStartup(GlobalDataBundle globalDataBundle)
        {
            _dataBundle = globalDataBundle;
        }

        public void InitializeSystems()
        {
            CreateSystems();

            InitializeInitSystems();
            InitializeUpdateSystems();
        }
        public void UpdateSystems()
        {
            _updateSystems?.Run();
        }
        public void FixedUpdateSystems()
        {
            _fixedUpdateSystems?.Run();
        }

        public void OnDestroySystems()
        {
            if (_initializeSystems != null)
            {
                _initializeSystems.Destroy();
                _initializeSystems = null;
            }
            if (_updateSystems != null)
            {
                _updateSystems.Destroy();
                _updateSystems = null;
            }
            if (_fixedUpdateSystems != null)
            {
                _fixedUpdateSystems.Destroy();
                _fixedUpdateSystems = null;
            }

            if (_world != null)
            {
                _world.Destroy();
                _world = null;
            }
        }

        private void CreateSystems()
        {
            _world = new EcsWorld();
            _initializeSystems = new EcsSystems(_world, _dataBundle);
            _updateSystems = new EcsSystems(_world, _dataBundle);
        }
        private void InitializeInitSystems()
        {
            _initializeSystems.Add(new StartSettingsSystem());
            _initializeSystems.Add(new AudioInitSystem());
            _initializeSystems.Inject();
            _initializeSystems.Init();
        }
        private void InitializeUpdateSystems()
        {
            _updateSystems.Add(new AudioRunSystem());
            _updateSystems.Inject();
            _updateSystems.Init();
        }
        private void InitializeFixedUpdateSystems()
        {
            _fixedUpdateSystems.Inject();
            _fixedUpdateSystems.Init();
        }
    }
}