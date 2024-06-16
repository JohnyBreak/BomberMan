using GameState;
using Utils;

public class GamePrepareState : IState
{
    private readonly GameStateMachine m_StateMachine;
    private readonly Transition _transition;

    public GamePrepareState(GameStateMachine stateMachine,Transition transition)
    {
        m_StateMachine = stateMachine;
        _transition = transition;
    }

    public void Enter()
    {
        // подготовить уровень, все заспавнить, открыть шторку и перейти в геймплей
        Prepare();
    }

    private async void Prepare() 
    {
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
