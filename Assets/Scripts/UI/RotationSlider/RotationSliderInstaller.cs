using UI.RotationSlider;
using Zenject;

public class RotationSliderInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind(typeof(RotationSliderPresenter),typeof(IInitializable)).To<RotationSliderPresenter>().AsCached().NonLazy();
        Container.Bind<IRotationSliderModel>().To<RotationSliderModel>().AsCached();
    }
}