using Utils;

namespace GameState
{
    public class LoadLevelState : IPayLoadState<string>
    {
        private readonly GameStateMachine m_StateMachine;
        private readonly SceneLoader m_SceneLoader;
        
        public LoadLevelState(GameStateMachine stateMachine, SceneLoader sceneLoader)
        {
            m_StateMachine = stateMachine;
            m_SceneLoader = sceneLoader;
        }
        public void Enter(string sceneName)
        {
            m_SceneLoader.Load(sceneName);
        }

        public void Exit()
        {
            
        }
    }
}