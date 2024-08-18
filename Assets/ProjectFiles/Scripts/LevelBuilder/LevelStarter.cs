using GameState;
using UnityEngine;

public class LevelStarter
{
    private TimerStarter _timerStarter;
    private MusicStarter _musicStarter;
    private LevelGenerator _levelGenerator;

    private IStorageService _storageService;
    private GameStateMachine _machine;

    public LevelStarter(
        GameStateMachine machine,
        IStorageService service,
        TimerStarter timerStarter,
        MusicStarter musicStarter,
        LevelGenerator levelGenerator)
    {
        _storageService = service;
        _machine = machine;
        _timerStarter = timerStarter;
        _levelGenerator = levelGenerator;
        _musicStarter = musicStarter;
        _machine.StateChangedEvent += OnStateChanged;
    }

    private void OnStateChanged(IExitableState state)
    {
        if (state is GamePrepareState)
        {
            InitLevel();
        }

        if (state is GamePlayState)
        {
            StartLevel();
        }
    }

    public void InitLevel()
    {
        _storageService.Load<int>("LevelNumber", (level) =>
        {
            Debug.Log(level);
        });

        _levelGenerator.Init(null);
        _timerStarter.InitTimer(new TimeDuration(03, 00));
    }

    public void StartLevel()
    {
        _timerStarter.StartTimer();
        _musicStarter.Init();

        _machine.StateChangedEvent -= OnStateChanged;
    }

    public void Dispose()
    {
        _machine.StateChangedEvent -= OnStateChanged;
    }
}
