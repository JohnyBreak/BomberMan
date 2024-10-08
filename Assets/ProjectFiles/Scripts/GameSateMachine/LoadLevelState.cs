using System;
using Utils;

namespace GameState
{
    public class LoadLevelState : IPayLoadState<LoadLevelPayLoad>
    {
        private readonly SceneLoader m_SceneLoader;
        
        public LoadLevelState(SceneLoader sceneLoader)
        {
            m_SceneLoader = sceneLoader;
        }

        public void Enter(LoadLevelPayLoad payload)
        {
            m_SceneLoader.Load(payload.SceneName, payload.OnLoadCallback);
        }

        public void Exit()
        {
            
        }
    }

    public struct LoadLevelPayLoad 
    {
        public string SceneName;
        public Action OnLoadCallback;

        public LoadLevelPayLoad(string sceneName, Action callback) 
        {
            SceneName = sceneName;
            OnLoadCallback = callback;
        }
    }
}