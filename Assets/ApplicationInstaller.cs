using UI;
using Zenject;

namespace DefaultNamespace
{
    public class ApplicationInstaller : MonoInstaller<ApplicationInstaller>
    {
        public override void InstallBindings()
        {
            UIInstaller
                .Install(Container);
        }
    }
}