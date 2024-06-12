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
        _gameStateMachine.Enter<LoadLevelState, LoadLevelPayLoad>(new LoadLevelPayLoad("MainScene", null));
    }

    public void Exit()
    {
    }
}
