using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Utils
{
    public class SceneLoader
    {
        private ICoroutineRunner m_CoroutineRunner;
        private readonly Transition _transition;

        public SceneLoader(ICoroutineRunner coroutineRunner, Transition transition)
        {
            m_CoroutineRunner = coroutineRunner;
            _transition = transition;
        }

        public void Load(string sceneName, Action onLoaded = null)
        {
            m_CoroutineRunner.StartCoroutine(LoadScene(sceneName, onLoaded));
            //_transition.FadeIn(() => 
            //{
            //    m_CoroutineRunner.StartCoroutine(LoadScene(sceneName, onLoaded));
            //});
        }

        private IEnumerator LoadScene(string sceneName, Action onLoaded = null, bool allowSameScene = false)
        {
            if (allowSameScene == false) 
            { 
                if (SceneManager.GetActiveScene().name == sceneName)
                {
                    onLoaded?.Invoke();

                    //_transition.FadeOut(() =>
                    //{
                    //    onLoaded?.Invoke();
                    //});

                
                    yield break;
                }
            }

            AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);

            while (operation.isDone == false)
            {
                yield return null;
            }

            onLoaded?.Invoke();
            //_transition.FadeOut(() =>
            //{
            //    onLoaded?.Invoke();
            //});
        }

        internal void ReLoad(string sceneName, Action onLoadCallback)
        {
            m_CoroutineRunner.StartCoroutine(LoadScene(sceneName, onLoadCallback, true));
            //_transition.FadeIn(() =>
            //{
            //    m_CoroutineRunner.StartCoroutine(LoadScene(sceneName, onLoadCallback, true));
            //});
        }
    }
}