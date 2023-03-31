using UI.RotationSlider;
using Zenject;

public class RotationSliderInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<RotationSliderPresenter>().AsCached().NonLazy();
        Container.Bind<IRotationSliderModel>().To<RotationSliderModel>().AsCached();
    }
}