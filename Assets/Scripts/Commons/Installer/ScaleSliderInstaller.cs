using UI.ScaleSlider;
using UnityEngine;
using Zenject;

public class ScaleSliderInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<ScaleSliderPresenter>().AsCached().NonLazy();
        Container.Bind<IScaleSliderModel>().To<ScaleSliderModel>().AsCached();
    }
}