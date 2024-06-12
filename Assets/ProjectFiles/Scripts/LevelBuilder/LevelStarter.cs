using GameState;
using UnityEngine;
using Zenject;

public class LevelStarter : MonoBehaviour
{
    [SerializeField] private TimerStarter _timerStarter;
    [SerializeField] private MusicStarter _musicStarter;
    [SerializeField] private LevelGenerator _levelGenerator;

    private IStorageService _service;
    private GameStateMachine _machine;

    [Inject]
    private void Construct(GameStateMachine machine, IStorageService service)
    {
        _service = service;
        _machine = machine;

        _machine.StateChangedEvent += OnStateChanged;
    }

    private void Awake()
    {
        _levelGenerator.Init();
    }

    private void Start()
    {
        _service.Load<int>("LevelNumber", (level) =>
        {
            Debug.Log(level);
        });
    }

    private void OnStateChanged(IExitableState state)
    {
        if (state is GamePlayState) 
        {
            StartLevel();
        }
    }

    private void StartLevel()
    {
        _timerStarter.Init();
        _musicStarter.Init();

        _machine.StateChangedEvent -= OnStateChanged;
    }

    private void OnDestroy()
    {
        _machine.StateChangedEvent -= OnStateChanged;
    }
}
