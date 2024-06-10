using GameState;
using Utils;

public class ReloadLevelState : IPayLoadState<LoadLevelPayLoad>
{
    private readonly GameStateMachine m_StateMachine;
    private readonly SceneLoader m_SceneLoader;

    public ReloadLevelState(GameStateMachine stateMachine, SceneLoader sceneLoader)
    {
        m_StateMachine = stateMachine;
        m_SceneLoader = sceneLoader;
    }
    public void Enter(LoadLevelPayLoad payload)
    {
        m_SceneLoader.ReLoad(payload.SceneName, payload.OnLoadCallback);
    }

    public void Exit()
    {

    }
}
