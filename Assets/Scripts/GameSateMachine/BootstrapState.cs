using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
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
            Debug.LogError("enter bootstrapstate");
            Prepare();
        }

        private async void Prepare()
        {
            var task = m_AssetProvider.InstantiateAsync("TransitionCanvas");
            await task;
            Transition transition = task.Result.GetComponent<Transition>();
            GameObject.DontDestroyOnLoad(transition.gameObject);
            transition.SetValue(0);
            transition.FadeIn(() =>
            {
                m_SceneLoader.Load("InitialScene", onLoaded: EnterLoadLevel);
            });
        }

        private void EnterLoadLevel()
        {
            m_StateMachine.Enter<LoadLevelState, string>("SampleScene");
        }

        public void Exit()
        {
            Debug.LogError("exit bootstrapstate");
        }
    }
}