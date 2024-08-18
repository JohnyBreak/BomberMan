using GameState;
using UnityEngine;
using Utils;
using Zenject;

public class GameRootInstaller : MonoInstaller
{
    [SerializeField] private Transition _screen;
    [SerializeField] private AudioManager _audioManager;
    [SerializeField] private AudioDB _audioDB;

    public override void InstallBindings()
    {
        Container.Bind<Transition>().FromMethod(CreateTransition).AsSingle().NonLazy();
        Container.Bind<AudioManager>().FromMethod(CreateAudioManager).AsSingle().NonLazy();
        Container.Bind<AudioDB>().FromInstance(_audioDB).AsSingle();

        Container.Bind<ICoroutineRunner>().To<CoroutineRunner>().FromMethod(CreateCoroutineRunner).AsSingle().NonLazy();

        Container.Bind<SceneLoader>().FromNew().AsSingle().NonLazy();

        Container.Bind<StateFactory>().FromNew().AsSingle().NonLazy();

        Container.Bind<GameObjectFactory>().FromNew().AsSingle();
        Container.Bind<Timer>().FromNew().AsSingle();
        Container.Bind<TimerStarter>().FromNew().AsSingle();
        Container.Bind<LevelGenerator>().FromNew().AsSingle();
        
        Container.Bind<LevelStarter>().FromNew().AsSingle();
        Container.Bind<MusicStarter>().FromNew().AsSingle().WithArguments("Music", true);

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

    private AudioManager CreateAudioManager(InjectContext context)
    {
        var component = context.Container.InstantiatePrefabForComponent<AudioManager>(_audioManager);

       
        DontDestroyOnLoad(component.gameObject);
        return component;
    }
}
