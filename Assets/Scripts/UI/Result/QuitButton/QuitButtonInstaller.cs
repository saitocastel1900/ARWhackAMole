using UI.Result.QuitButton;
using Zenject;

public class QuitButtonInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind(typeof(QuitButtonPresenter),typeof(IInitializable)).To<QuitButtonPresenter>().AsCached().NonLazy();
        Container.Bind<IQuitButtonModel>().To<QuitButtonModel>().AsCached();
    }
}