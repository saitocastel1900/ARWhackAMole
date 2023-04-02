using UI.Result.RestartButton;
using UnityEngine;
using Zenject;

public class RestartButtonInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind(typeof(RestartButtonPresenter),typeof(IInitializable)).To<RestartButtonPresenter>().AsCached().NonLazy();
        Container.Bind<IRestartButtonModel>().To<RestartButtonModel>().AsCached();
    }
}