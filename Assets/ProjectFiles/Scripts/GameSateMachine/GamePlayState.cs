using GameState;
using Utils;

public class GamePlayState : IState
{
    private GameStateMachine gameStateMachine;

    public GamePlayState(GameStateMachine gameStateMachine)
    {
        this.gameStateMachine = gameStateMachine;
    }

    public void Enter()
    {
    }

    public void Exit()
    {
    }
}
