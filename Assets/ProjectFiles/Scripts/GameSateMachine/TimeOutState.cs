using GameState;

public class TimeOutState : IState
{
    private GameStateMachine _gameStateMachine;

    public TimeOutState(GameStateMachine gameStateMachine)
    {
        _gameStateMachine = gameStateMachine;
    }

    public void Enter()
    {
        _gameStateMachine.Enter<ReloadLevelState, LoadLevelPayLoad>(new LoadLevelPayLoad("CoreScene", () =>
        {
            _gameStateMachine.Enter<GamePlayState>();
        }));
    }

    public void Exit()
    {
    }
}
