using GameState;

public class TimerStarter
{
    private TimeDuration _durationUnit = new TimeDuration(3,0);

    private Timer _timer;
    private GameStateMachine _gameStateMachine;

    public TimerStarter(Timer timer, GameStateMachine gameStateMachine)
    {
        _timer = timer;
        _gameStateMachine = gameStateMachine;
        _gameStateMachine.StateChangedEvent += OnStateChanged;
    }

    public void InitTimer(TimeDuration durationUnit)
    {
        _durationUnit = durationUnit;

        _timer.Init((int)_durationUnit.GetTotalSeconds(), 0, null, OnComplite);
    }

    public void StartTimer()
    {
        _timer.Start();
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

    public void Dispose()
    {
        _gameStateMachine.StateChangedEvent -= OnStateChanged;
        _timer.Stop();
    }
}
