using Assets.Code.Controller;
using Zenject;

namespace Assets.Code.Helper
{
    public class GameInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<IGameController>().To<GameController>().AsSingle();
            Container.Bind<IPlayerController>().To<PlayerController>().AsSingle();
            Container.Bind<IStatController>().To<StatController>().AsSingle();
        }
    }
}