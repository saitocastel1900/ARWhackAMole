using UI.ResetButton;
using UI.Result.ResetButton;
using Zenject;

public class ResetButtonInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<ResetButtonPresenter>().AsCached().NonLazy();
        Container.Bind<IResetButtonModel>().To<ResetButtonModel>().AsCached();
    }
}
