using DG.Tweening;
using System;
using UnityEngine;

public class TransitionScreen : MonoBehaviour
{
    [SerializeField] private CanvasGroup _canvasGroup;
    [SerializeField] private float _fadeDuration;

    public void FadeIn(Action callBack = null)
    {
        _canvasGroup
            .DOFade(1, _fadeDuration)
            .OnComplete(() =>
                {
                    callBack?.Invoke();
                }
            );
    }

    public void FadeOut(Action callBack = null)
    {
        _canvasGroup
            .DOFade(0, _fadeDuration)
            .OnComplete(() =>
                {
                    callBack?.Invoke();
                }
            );
    }
}
