using Sdk.CodeBase.Utilities;
using Zenject;

namespace Sdk.CodeBase.Installers
{
    public class UtilitiesInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindSpawnPointProvider();
            BindCoroutineRunner();
        }

        private void BindSpawnPointProvider()
        {
            var spawnPoints = FindObjectOfType<SpawnPointProvider>();
            
            Container.Bind(typeof(SpawnPointProvider), typeof(ISpawnPointProvider))
                .To<SpawnPointProvider>()
                .FromInstance(spawnPoints)
                .AsSingle();
        }

        private void BindCoroutineRunner()
        {
            var coroutineRunner = FindObjectOfType<CoroutineRunner>();
            
            Container.Bind(typeof(CoroutineRunner), typeof(ICoroutineRunner))
                .To<CoroutineRunner>()
                .FromInstance(coroutineRunner)
                .AsSingle();
        }
    }
}