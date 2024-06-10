using GameState;
using Utils;
using Zenject;

public class GameStateInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Transition transition = Container.Resolve<Transition>();

        ICoroutineRunner runner = FindObjectOfType<BootStrap>();

        SceneLoader sceneLoader = new SceneLoader(runner, transition);

        GameStateMachine machine = new GameStateMachine(sceneLoader);

        Container.Bind<GameStateMachine>().FromInstance(machine).AsSingle();
    }
}
