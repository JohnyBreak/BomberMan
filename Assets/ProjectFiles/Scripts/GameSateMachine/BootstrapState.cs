using Utils;

namespace GameState
{
    public class BootstrapState : IState
    {
        private readonly GameStateMachine m_StateMachine;
        private readonly SceneLoader m_SceneLoader;
        private readonly Transition _transition;
        public BootstrapState(GameStateMachine stateMachine, SceneLoader sceneLoader, Transition transition)
        {
            m_StateMachine = stateMachine;
            m_SceneLoader = sceneLoader;
            _transition = transition;
        }

        public void Enter()
        {
            m_SceneLoader.Load("BootStrapScene", onLoaded: EnterLoadLevel);
        }

        private void EnterLoadLevel()
        {
            m_StateMachine.Enter<LoadLevelState, LoadLevelPayLoad>(new LoadLevelPayLoad("MainScene", () => 
            {
                _transition.FadeOut();
            }));
        }

        public void Exit()
        {
        }
    }
}