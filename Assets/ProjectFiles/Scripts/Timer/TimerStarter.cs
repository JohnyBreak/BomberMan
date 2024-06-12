using GameState;
using UnityEngine;
using Zenject;

public class TimerStarter : MonoBehaviour
{
    [SerializeField] private TimeDuration _durationUnit;

    private Timer _timer;
    private GameStateMachine _gameStateMachine;

    [Inject]
    private void Construct(Timer timer, GameStateMachine gameStateMachine)
    {
        _timer = timer;
        _gameStateMachine = gameStateMachine;
    }

    private void Start()
    {
        _gameStateMachine.StateChangedEvent += OnStateChanged;

        _timer.Start((int)_durationUnit.GetTotalSeconds(), 0, null, OnComplite);    
    }


    private void OnStateChanged(IExitableState state)
    {
        if (state is GamePauseState) 
        {
            _timer.Pause();
            return;
        }

        if (state is GamePlayState) 
        {
            _timer.Resume(); 
            return;
        }
    }

    private void OnComplite()
    {
        _gameStateMachine.Enter<TimeOutState>();
    }

    private void OnDestroy()
    {
        _gameStateMachine.StateChangedEvent -= OnStateChanged;
        _timer.Stop();
    }
}
