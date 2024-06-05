using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Utils
{
    public class SceneLoader
    {
        private readonly ICoroutineRunner m_CoroutineRunner;

        public SceneLoader(ICoroutineRunner coroutineRunner)
        {
            m_CoroutineRunner = coroutineRunner;
        }

        public void Load(string sceneName, Action onLoaded = null)
        {
            m_CoroutineRunner.StartCoroutine(LoadScene(sceneName, onLoaded));
        }

        private IEnumerator LoadScene(string sceneName, Action onLoaded = null)
        {
            if (SceneManager.GetActiveScene().name == sceneName)
            {
                onLoaded?.Invoke();
                yield break;
            }

            AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);

            while (operation.isDone == false)
            {
                yield return null;
            }
            
            onLoaded?.Invoke();
        }
    }
}