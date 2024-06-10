using GameState;

public class WinState : IState
{
    private GameStateMachine _gameStateMachine;

    public WinState(GameStateMachine gameStateMachine)
    {
        this._gameStateMachine = gameStateMachine;
    }

    public void Enter()
    {
    }

    public void Exit()
    {
    }
}
