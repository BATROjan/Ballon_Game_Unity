using Zenject;

namespace DefaultNamespace.Balloon
{
    public class BalloonInstaller: Installer<BalloonInstaller>
    {
        public override void InstallBindings()
        {
            /*Container
                .Bind<CoinConfig>()
                .FromScriptableObjectResource("CoinConfig")
                .AsSingle()
                .NonLazy();*/
            
            Container
                .Bind<BalloonController>()
                .AsSingle()
                .NonLazy();
            
            Container
                .BindMemoryPool<BalloonView, BalloonView.Pool>()
                .FromComponentInNewPrefabResource("Balloon");
        }
    }
}