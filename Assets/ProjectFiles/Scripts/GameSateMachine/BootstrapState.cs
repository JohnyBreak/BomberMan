using Utils;

namespace GameState
{
    public class BootstrapState : IState
    {
        private readonly GameStateMachine m_StateMachine;
        private readonly SceneLoader m_SceneLoader;
        
        public BootstrapState(GameStateMachine stateMachine, SceneLoader sceneLoader)
        {
            m_StateMachine = stateMachine;
            m_SceneLoader = sceneLoader;
        }

        public void Enter()
        {
            m_SceneLoader.Load("BootStrapScene", onLoaded: EnterLoadLevel);
        }

        private void EnterLoadLevel()
        {
            m_StateMachine.Enter<LoadLevelState, LoadLevelPayLoad>(new LoadLevelPayLoad("MainScene", null));
        }

        public void Exit()
        {
        }
    }
}