using UI.UIResultWindow;
using UI.UIService;
using UI.UIStartWindow;
using Zenject;

namespace UI
{
    public class UIInstaller : Installer<UIInstaller>
    {
        public override void InstallBindings()
        {
            UIStartWindowInstaller.Install(Container);
            UIResultWindowInstaller.Install(Container);
            
            Container.Bind<IUIRoot>()
                .FromComponentInNewPrefabResource("UIRoot")
                .AsSingle()
                .NonLazy();

            Container
                .Bind<IUIService>()
                .To<UIService
                    .UIService>()
                .AsSingle()
                .NonLazy();
        }
    }
}