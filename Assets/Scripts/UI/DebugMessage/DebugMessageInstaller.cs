using UI.DebugMessage;
using Zenject;

namespace Installer
{
    public class DebugMessageInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind(typeof(DebugMessagePresenter),typeof(IInitializable)).To<DebugMessagePresenter>().FromNew().AsCached().NonLazy();
            Container.Bind<IDebugMessageModel>().To<DebugMessageModel>().FromNew().AsCached();
        }
    }
}