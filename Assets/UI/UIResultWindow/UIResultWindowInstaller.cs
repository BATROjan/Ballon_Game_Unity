using Zenject;

namespace UI.UIResultWindow
{
    public class UIResultWindowInstaller: Installer<UIResultWindowInstaller>
    {
        public override void InstallBindings()
        {
            Container
                .Bind<PlayerResultConfig>()
                .FromScriptableObjectResource("PlayerResultConfig")
                .AsSingle()
                .NonLazy();
            
            Container
                .BindMemoryPool<PlayerResultView, PlayerResultView.Pool>()
                .FromComponentInNewPrefabResource("PlayerResultView");
            
            Container
                .Bind<UIResultWindowController>()
                .AsSingle()
                .NonLazy();
        }
    }
}