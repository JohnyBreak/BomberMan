using Utils;

namespace GameState
{
    public class BootstrapState : IState
    {
        private readonly GameStateMachine m_StateMachine;
        private readonly SceneLoader m_SceneLoader;
        private readonly AssetProvider m_AssetProvider;
        
        public BootstrapState(GameStateMachine stateMachine, SceneLoader sceneLoader, AssetProvider assetProvider)
        {
            m_StateMachine = stateMachine;
            m_SceneLoader = sceneLoader;
            m_AssetProvider = assetProvider;
        }

        public void Enter()
        {
            Prepare();
        }

        private async void Prepare()
        {
            var task = m_AssetProvider.InstantiateAsync("TransitionCanvas");
            await task;

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