using GameState;
using Utils;

public class GamePrepareState : IState
{
    private readonly GameStateMachine m_StateMachine;
    private readonly Transition _transition;
    private readonly LevelStarter _levelStarter;

    public GamePrepareState(GameStateMachine stateMachine,Transition transition, LevelStarter levelStarter)
    {
        m_StateMachine = stateMachine;
        _transition = transition;
        _levelStarter = levelStarter;
    }

    public void Enter()
    {
        // подготовить уровень, все заспавнить, открыть шторку и перейти в геймплей
        Prepare();
    }

    private async void Prepare()
    {
        _levelStarter.InitLevel();

        _transition.FadeOut(EnterGamePlay);
    }

    private void EnterGamePlay()
    {
        m_StateMachine.Enter<GamePlayState>();
    }

    public void Exit()
    {
    }
}
