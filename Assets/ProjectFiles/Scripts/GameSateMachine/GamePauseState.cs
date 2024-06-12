using GameState;

public class GamePauseState : IState
{
    private GameStateMachine _gameStateMachine;

    public GamePauseState(GameStateMachine gameStateMachine)
    {
        _gameStateMachine = gameStateMachine;
    }

    public void Enter()
    {
    }

    public void Exit()
    {
    }
}
