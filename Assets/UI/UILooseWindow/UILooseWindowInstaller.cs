using Zenject;

namespace UI.UILooseWindow
{
    public class UILooseWindowInstaller : Installer<UILooseWindowInstaller>
    {
        public override void InstallBindings()
        {
            Container
                .Bind<UILooseWindowController>()
                .AsSingle()
                .NonLazy();
        }
    }
}