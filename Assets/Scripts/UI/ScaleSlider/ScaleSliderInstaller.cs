using UI.Main.ScaleSlider;
using Zenject;

public class ScaleSliderInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind(typeof(ScaleSliderPresenter),typeof(IInitializable)).To<ScaleSliderPresenter>().AsCached().NonLazy();
        Container.Bind<IScaleSliderModel>().To<ScaleSliderModel>().AsCached();
    }
}