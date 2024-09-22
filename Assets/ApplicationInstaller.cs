using DefaultNamespace.Balloon;
using DragController;
using Installer.CameraInstaller;
using UI;
using Zenject;

namespace DefaultNamespace
{
    public class ApplicationInstaller : MonoInstaller<ApplicationInstaller>
    {
        public override void InstallBindings()
        {
            BalloonInstaller
                .Install(Container);
            CameraInstaller
                .Install(Container);
            DragControllerInstaller
                .Install(Container);
            UIInstaller
                .Install(Container);
            Container.Bind<GameController.GameController>().AsSingle().NonLazy();
        }
    }
}