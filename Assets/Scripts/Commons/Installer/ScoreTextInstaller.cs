using UI.ScoreText;
using Zenject;

public class ScoreTextInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<ScoreTextPresenter>().AsCached().NonLazy();
        Container.Bind<IScoreTextModel>().To<ScoreTextModel>().AsCached();
    }
}