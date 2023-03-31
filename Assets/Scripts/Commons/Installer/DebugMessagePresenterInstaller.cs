using UI.DebugMessage;
using Zenject;

namespace Installer
{
    public class DebugMessagePresenterInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<DebugMessagePresenter>().FromNew().AsCached().NonLazy();
            Container.Bind<IDebugMessageModel>().To<DebugMessageModel>().FromNew().AsCached();
        }
    }
}