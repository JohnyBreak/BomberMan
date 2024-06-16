using GameState;
using UnityEngine;
using Utils;
using Zenject;

public class GameRootInstaller : MonoInstaller
{
    [SerializeField] private Transition _screen;

    public override void InstallBindings()
    {
        Container.Bind<Transition>().FromMethod(CreateTransition).AsSingle().NonLazy();

        Container.Bind<ICoroutineRunner>().To<CoroutineRunner>().FromMethod(CreateCoroutineRunner).AsSingle().NonLazy();

        Container.Bind<SceneLoader>().FromNew().AsSingle().NonLazy();

        Container.Bind<StateFactory>().FromNew().AsSingle().NonLazy();

        Container.Bind<BootstrapState>().FromNew().AsSingle().NonLazy();
        Container.Bind<LoadLevelState>().FromNew().AsSingle().NonLazy();
        Container.Bind<WinState>().FromNew().AsSingle().NonLazy();
        Container.Bind<LoseState>().FromNew().AsSingle().NonLazy();
        Container.Bind<GamePlayState>().FromNew().AsSingle().NonLazy();
        Container.Bind<ReloadLevelState>().FromNew().AsSingle().NonLazy();
        Container.Bind<TimeOutState>().FromNew().AsSingle().NonLazy();
        Container.Bind<GamePauseState>().FromNew().AsSingle().NonLazy();
        Container.Bind<GamePrepareState>().FromNew().AsSingle().NonLazy();

        Container.Bind<AssetProvider>().FromNew().AsSingle().NonLazy();

        Container.Bind<GameStateMachine>().FromNew().AsSingle().NonLazy();
    }

    private CoroutineRunner CreateCoroutineRunner() 
    {
        GameObject runnerObject = new GameObject();
        runnerObject.name = "CoroutineRunner";
        CoroutineRunner runnerComponent = runnerObject.AddComponent<CoroutineRunner>();

        DontDestroyOnLoad(runnerObject);

        return runnerComponent;
    }

    private Transition CreateTransition(InjectContext context) 
    {
        var transition = context.Container.InstantiatePrefabForComponent<Transition>(_screen);

        transition.SetValue(1);
        transition.transform.SetParent(null, false);
        DontDestroyOnLoad(transition.gameObject);
        return transition;
    }
}
