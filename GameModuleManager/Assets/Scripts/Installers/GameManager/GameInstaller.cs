using Zenject;
using FSM.GameManager;
using FSM.GameManager.States;
using FSM.Helper;
using InputReader;

namespace FSM.Installers
{
    public class GameInstaller : MonoInstaller<GameInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<GameManager.GameManager>()
                .FromNewComponentOnNewGameObject()
                .WithGameObjectName("GameManager")
                .AsSingle()
                .NonLazy();
            Container.BindFactory<GameManager.GameManager, GameManager.GameManager.Factory>().AsSingle();

            InstallGameManager();
            InstallMisc();
        }

        private void InstallGameManager()
        {
            Container.Bind<GameStateFactory>().AsSingle();
            Container.BindInterfacesAndSelfTo<InputModule>().AsSingle();

            Container.BindInterfacesAndSelfTo<MenuState>().AsSingle();
            Container.BindInterfacesAndSelfTo<GameplayState>().AsSingle();
            Container.BindInterfacesAndSelfTo<GameOverState>().AsSingle();
            Container.BindInterfacesAndSelfTo<VictoryState>().AsSingle();

            Container.BindFactory<MenuState, MenuState.Factory>().WhenInjectedInto<GameStateFactory>();
            Container.BindFactory<GameplayState, GameplayState.Factory>().WhenInjectedInto<GameStateFactory>();
            Container.BindFactory<GameOverState, GameOverState.Factory>().WhenInjectedInto<GameStateFactory>();
            Container.BindFactory<VictoryState, VictoryState.Factory>().WhenInjectedInto<GameStateFactory>();
        }

        private void InstallMisc()
        {
            Container.Bind<AsyncProcessor>().FromNewComponentOnNewGameObject().AsSingle();
        }
    }
}